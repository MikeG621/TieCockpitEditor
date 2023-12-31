/*
 * TieCockpitEditor.exe, Cockpit editor for TIE95
 * Copyright (C) 2009 Michael Gaisser (mjgaisser@gmail.com)
 * 
 * This software is free software; you can redistribute it and/or modify it
 * under the terms of the Mozilla Public License; either version 2.0 of the
 * License, or (at your option) any later version.
 *
 * This software is "as is" without warranty of any kind; including that the
 * software is free of defects, merchantable, fit for a particular purpose or
 * non-infringing. See the full license text for more details.
 *
 * If a copy of the MPL (License.txt) was not distributed with this file,
 * you can obtain one at http://mozilla.org/MPL/2.0/.
 * 
 * VERSION: 0.9.1
 */

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Idmr.LfdReader;

namespace Idmr.CockpitEditor
{
	public partial class MainForm : Form
	{
		ColorPalette _palette;
		Mask _viewMask;
		Panl _viewPanl;
		Pltt _viewPltt;
		Panl _itemsPanl;
		int _numberOfImages = 0;
		int _activeItem;
		readonly long[] _offsets = new long[2];
		TieInt _cockpit;
		TieInt.ViewIndex _currentView;
		Bitmap _view = new Bitmap(640, 456);
		bool _loading = false;
		bool _mirror = false;

		public MainForm()
		{
			InitializeComponent();
			lblItem.Text = "None";
			lblVar1.Text = "None";
			lblVar2.Text = "None";
			lblZoom.Text = "";
			Height = 600;
			Width = 1170;
			cboStatus.Items.AddRange(Enum.GetNames(typeof(TieInt.ViewStatus)));
			cboView.Items.AddRange(Enum.GetNames(typeof(TieInt.ViewIndex)));
			cboPanlIndex.Items.AddRange(Enum.GetNames(typeof(TieInt.PanlItemIndex)));
			cboItems.Items.AddRange(Enum.GetNames(typeof(TieInt.LayoutIndex)));
			panLaser.Location = numVar2.Location;
			cboPanlIndex.Location = numVar1.Location;
		}

		private void DisplayItem(int index)
		{
			if (index == -1)
			{
				_numberOfImages = 0;
				pctItem.BackgroundImage = null;
				cmdNext.Enabled = false;
				cmdPrev.Enabled = false;
				lblZoom.Text = "";
				lblItem.Text = "None";
				return;
			}
			lblItem.Text = " (" + (index-cboPanlIndex.SelectedIndex+1) + " of " + _numberOfImages + ")";
			if (cboItems.SelectedIndex >= (int)TieInt.LayoutIndex.CmdFrame  && cboItems.SelectedIndex <= (int)TieInt.LayoutIndex.BeamPowerFrame
				&& index != cboPanlIndex.SelectedIndex) index += 12;
			lblItem.Text = cboPanlIndex.Items[index].ToString() + lblItem.Text;
			Bitmap image = new Bitmap(_itemsPanl.Images[index]);
			int mult = 1;
			if (image.Width < 85 && image.Height < 40) mult = 4;
			else if (image.Width < 175 && image.Height < 80) mult = 2;
			pctItem.BackgroundImage = new Bitmap(image, new Size(image.Width*mult, image.Height*mult));
			lblZoom.Text = "Zoom: " + mult + "x";
			pctMask.Invalidate();
		}
		private void DisplayView()
		{
			_mirror = false;
			string path;
			path = _cockpit.FileDirectory + _cockpit.Views[(int)_currentView].Lfd + ".lfd";
			TieInt.ViewStatus stat = _cockpit.Views[(int)_currentView].Status;
			if (stat == TieInt.ViewStatus.Default)
				path = _cockpit.FileDirectory + _cockpit.Views[(int)TieInt.ViewIndex.Default].Lfd + ".lfd";
			if ((int)stat >= 0xC0)
			{
				_mirror = true;
				path = _cockpit.FileDirectory + _cockpit.Views[(int)stat - 0xC0].Lfd + ".lfd";
			}
			if (stat != TieInt.ViewStatus.Absent && path != _cockpit.FileDirectory + ".lfd")
			{
				_offsets[0] = Resource.GetLength(path, 0) + Resource.HeaderLength;
				_offsets[1] = Resource.GetLength(path, _offsets[0]) + _offsets[0] + Resource.HeaderLength;
				_viewPltt = new Pltt(path, _offsets[1]);
				_viewMask = new Mask(path, _offsets[0]);
				_palette = _viewPltt.Palette;
				_palette.Entries[0] = Color.FromArgb(255, 0, 255);  // transparent marker
				_viewPanl = new Panl(path, 0, _palette);
				if (_currentView == TieInt.ViewIndex.Forward && _itemsPanl == null)
				{
					path = _cockpit.FileDirectory + _cockpit.Panel + ".pnl";
					_itemsPanl = new Panl(path, 0, _palette);
				}
				_view = new Bitmap(_viewPanl.Images[0]);
			}
			else
			{
				_view = new Bitmap(1, 1);
				_viewMask = null;
				_viewPanl = null;
				_viewPltt = null;
				cmdMask.Enabled = false;
			}
			numMaskX.Value = _cockpit.Views[(int)_currentView].MaskX;
			numMaskY.Value = _cockpit.Views[(int)_currentView].MaskY;
			numMaskWidth.Value = _cockpit.Views[(int)_currentView].MaskWidth;
			numMaskHeight.Value = _cockpit.Views[(int)_currentView].MaskHeight;
			numYAxis.Value = _cockpit.Views[(int)_currentView].YAxis;
			txtLfd.Text = _cockpit.Views[(int)_currentView].Lfd;
			txtName.Text = _cockpit.Views[(int)_currentView].Name;
			int[] status = (int[])Enum.GetValues(typeof(TieInt.ViewStatus));
			for (int i=0;i<status.Length;i++)
			{
				if ((int)stat == status[i])
				{
					cboStatus.SelectedIndex = i;
					break;
				}
			}
			pctMask.Invalidate();
			if (_currentView == TieInt.ViewIndex.Forward || _currentView == TieInt.ViewIndex.ThreatDisplay) panItems.Enabled = true;
			else panItems.Enabled = false;
		}

		private void cmdOpen_Click(object sender, EventArgs e)
		{
			opnFile.ShowDialog();
		}

		private void opnFile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			_loading = true;
			_itemsPanl = null;
			panView.Enabled = false;
			cmdPanl.Enabled = false;
			try
			{
				cmdMask.Enabled = true;
				lblFile.Text = opnFile.FileName;
				_cockpit = new TieInt(opnFile.FileName);
				cboView.SelectedIndex = -1;
				cboView.SelectedIndex = 0;
				cboItems.SelectedIndex = 0;
				panView.Enabled = true;
				Text = "Cockpit Editor - TIE - " + _cockpit.FileName;
			}
			catch
			{
				MessageBox.Show("Error loading cockpit data, please ensure file is proper TIE95 cockpit INT");
				lblFile.Text = "(No File open)";
				_cockpit = null;
				_viewPltt = null;
				_viewMask = null;
				_viewPanl = null;
				pctMask.Image = null;
			}
			_loading = false;
		}

		private void pctMask_Paint(object sender, PaintEventArgs e)
		{
			Graphics g;
			g = e.Graphics;
			g.Clear(Color.Black);
			// main view
			_view.MakeTransparent(Color.FromArgb(255, 0, 255));
			if (_mirror)
			{
				_view.RotateFlip(RotateFlipType.RotateNoneFlipX);
				g.DrawImageUnscaled(_view, new Point());
				_view.RotateFlip(RotateFlipType.RotateNoneFlipX);
			}
			else g.DrawImageUnscaled(_view, new Point());
			// items
			if (_cockpit == null || cboItems.SelectedIndex == -1 || cmdPanl.Enabled || optDisplayNone.Checked) return;
			int index = cboItems.SelectedIndex;
			if (_cockpit.Layouts[index].X == 0 && _cockpit.Layouts[index].Y == 0) return;
			if (_currentView == TieInt.ViewIndex.Forward &&
				(index < (int)TieInt.LayoutIndex.ThreatDisplayName || index > (int)TieInt.LayoutIndex.ThreatDisplayTime))
			{
				Point pt = new Point(_cockpit.Layouts[index].X-1, _cockpit.Layouts[index].Y-1);
				Size sz = new Size { Height = 10 };
				if (index == (int)TieInt.LayoutIndex.FrontSensors || index == (int)TieInt.LayoutIndex.RearSensors)
				{
					sz = new Size(80, 80);
					pt = new Point(pt.X-40, pt.Y-40);
				}
				else if (index == (int)TieInt.LayoutIndex.Cmd)
					sz = new Size(_cockpit.Layouts[index].Argument1, _cockpit.Layouts[index].Argument2);
				else if (index == (int)TieInt.LayoutIndex.MissionTime) sz.Width = 26;
				else if (index == (int)TieInt.LayoutIndex.CameraTime) sz.Width = 18;
				else if (TieInt.LayoutArguments[index, 0] == TieInt.LayoutArgument.Digit)
					sz.Width = (_cockpit.Layouts[index].Argument1 == 0 ? 8 : _cockpit.Layouts[index].Argument1 * 6);
				else if (index == (int)TieInt.LayoutIndex.CmdBeamCharge) sz = new Size(50, 50);
				else sz.Width = 36;
				if (pctItem.BackgroundImage != null)
				{
					Bitmap item;
					if (index >= (int)TieInt.LayoutIndex.CmdFrame && index <= (int)TieInt.LayoutIndex.BeamPowerFrame
						&& cboPanlIndex.SelectedIndex != _activeItem) item = new Bitmap(_itemsPanl.Images[_activeItem + 12]);
					else item = new Bitmap(_itemsPanl.Images[_activeItem]);
					if (index == (int)TieInt.LayoutIndex.BeamSegments)
					{
						pt.X += (8 - (_activeItem - cboPanlIndex.SelectedIndex)) * 3;
						pt.Y += (8 - (_activeItem - cboPanlIndex.SelectedIndex)) * 3;
					}
					item.MakeTransparent(Color.FromArgb(255,0,255));
					sz = item.Size;
					if (index >= (int)TieInt.LayoutIndex.EnginePower && index <= (int)TieInt.LayoutIndex.BeamPower)
					{
						if (optDisplayItem.Checked) for (int i=0;i<6;i++) g.DrawImageUnscaled(item, pt.X+1, pt.Y+1 - i*6);
						sz.Height *= 12;
						pt.Y -= sz.Height - 6;
					}
					else if (index >= (int)TieInt.LayoutIndex.Laser1 && index <= (int)TieInt.LayoutIndex.Laser8)
					{
						pt.X -= 3;
						sz.Width *= 11;
						if (optLaserRight.Checked)
						{
							pt.X -= sz.Width - 7;
							item.RotateFlip(RotateFlipType.RotateNoneFlipX);
						}
						if (optDisplayItem.Checked) for (int i=0;i<11;i++) g.DrawImageUnscaled(item, pt.X+1 + i*6, pt.Y+1);
					}
					else if (optDisplayItem.Checked) g.DrawImageUnscaled(item, pt.X+1, pt.Y+1);
				}
				sz.Width++;
				sz.Height++;
				g.DrawRectangle(new Pen(Color.Red), new Rectangle(pt, sz));
			}
			else if (_currentView == TieInt.ViewIndex.ThreatDisplay && 
				index >= (int)TieInt.LayoutIndex.ThreatDisplayName && index <= (int)TieInt.LayoutIndex.ThreatDisplayTime)
			{
				Point pt = new Point(_cockpit.Layouts[index].X-1, _cockpit.Layouts[index].Y-1);
				Size sz = new Size { Height = 10 };
				if (TieInt.LayoutArguments[index, 0] == TieInt.LayoutArgument.Digit)
					sz.Width = (_cockpit.Layouts[index].Argument1 == 0 ? 8 : _cockpit.Layouts[index].Argument1 * 6);
				else sz.Width = 80;
				if (pctItem.BackgroundImage != null)
				{
					Bitmap item;
					item = new Bitmap(_itemsPanl.Images[_activeItem]);
					item.MakeTransparent(Color.FromArgb(255, 0, 255));
					sz = item.Size;
					if (optDisplayItem.Checked) g.DrawImageUnscaled(item, pt.X+1, pt.Y+1);
				}
				sz.Width++;
				sz.Height++;
				g.DrawRectangle(new Pen(Color.Red), new Rectangle(pt, sz));
			}
		}

		#region panView
		private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
		{
			cmdPanl.Enabled = false;
			cmdMask.Enabled = true;
			if (cboStatus.Text == "Absent") cmdMask.Enabled = false;
			int[] values = (int[])Enum.GetValues(typeof(TieInt.ViewStatus));
			if (!_loading)
			{
				_cockpit.Views[(int)_currentView].Status = (TieInt.ViewStatus)values[cboStatus.SelectedIndex];
				DisplayView();
			}
		}
		private void cboView_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboView.SelectedIndex == -1) return;
			_currentView = (TieInt.ViewIndex)cboView.SelectedIndex;
			cmdPanl.Enabled = false;
			cmdMask.Enabled = true;
			_loading = true;
			DisplayView();
			_loading = false;
		}

		private void cmdMask_Click(object sender, EventArgs e)
		{
			panItems.Enabled = false;
			cmdPanl.Enabled = true;
			cmdMask.Enabled = false;
			Graphics g = Graphics.FromImage(_view);
			g.DrawImageUnscaled(_viewMask.Image, _cockpit.Views[(int)_currentView].MaskX, _cockpit.Views[(int)_currentView].MaskY);
			g.Dispose();
			pctMask.Invalidate();
		}
		private void cmdPanl_Click(object sender, EventArgs e)
		{
			if (_currentView == TieInt.ViewIndex.Forward || _currentView == TieInt.ViewIndex.ThreatDisplay) panItems.Enabled = true;
			_view = new Bitmap(_viewPanl.Images[0]);
			pctMask.Invalidate();
			cmdPanl.Enabled = false;
			cmdMask.Enabled = true;
		}

		private void numMaskX_ValueChanged(object sender, EventArgs e)
		{
			if (_loading) return;
			_cockpit.Views[(int)_currentView].MaskX = (short)numMaskX.Value;
			_view = new Bitmap(_viewPanl.Images[0]);
			cmdMask_Click("numMaskX", new EventArgs());
		}
		private void numMaskY_ValueChanged(object sender, EventArgs e)
		{
			if (_loading) return;
			_cockpit.Views[(int)_currentView].MaskY = (short)numMaskY.Value;
			_view = new Bitmap(_viewPanl.Images[0]);
			cmdMask_Click("numMaskY", new EventArgs());
		}
		#endregion

		#region panItems
		private void cboItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool loading = _loading;
			_loading = true;
			int index = cboItems.SelectedIndex;
			numItemX.Value = _cockpit.Layouts[index].X;
			numItemY.Value = _cockpit.Layouts[index].Y;
			lblVar1.Text = TieInt.LayoutArguments[index, 0].ToString();
			lblVar2.Text = TieInt.LayoutArguments[index, 1].ToString();
			_numberOfImages = TieInt.NumberOfImages[cboItems.SelectedIndex];
			cmdPrev.Enabled = false;
			if (TieInt.LayoutArguments[index, 0] == TieInt.LayoutArgument.PanlIndex
				&& (_cockpit.Layouts[index].X != 0 || _cockpit.Layouts[index].Y != 0))
			{
				numVar1.Visible = false;
				cboPanlIndex.Visible = true;
				cboPanlIndex.SelectedIndex = _cockpit.Layouts[index].Argument1;
				cboPanlIndex_SelectedIndexChanged("cboItems_SelectedIndexChanged", new EventArgs());	// force it
				if (_numberOfImages > 1) cmdNext.Enabled = true;
				else cmdNext.Enabled = false;
			}
			else
			{
				numVar1.Value = _cockpit.Layouts[index].Argument1;
				numVar1.Visible = true;
				cboPanlIndex.Visible = false;
				cboPanlIndex.SelectedIndex = -1;
				pctMask.Invalidate();
			}
			if (TieInt.LayoutArguments[index, 1] == TieInt.LayoutArgument.Laser)
			{
				numVar2.Visible = false;
				panLaser.Visible = true;
				optLaserRight.Checked = Convert.ToBoolean(_cockpit.Layouts[index].Argument2);
				optLaserLeft.Checked = !optLaserRight.Checked;
			}
			else
			{
				numVar2.Value = _cockpit.Layouts[index].Argument2;
				numVar2.Visible = true;
				panLaser.Visible = false;
			}
			_loading = loading;
		}
		private void cboPanlIndex_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_loading) _cockpit.Layouts[cboItems.SelectedIndex].Argument1 = Convert.ToByte(cboPanlIndex.SelectedIndex);
			_activeItem = cboPanlIndex.SelectedIndex;
			DisplayItem(_activeItem);
		}

		private void cmdNext_Click(object sender, EventArgs e)
		{
			cmdPrev.Enabled = true;
			_activeItem++;
			DisplayItem(_activeItem);
			if (_activeItem-cboPanlIndex.SelectedIndex+1 == _numberOfImages) cmdNext.Enabled = false;
		}
		private void cmdPrev_Click(object sender, EventArgs e)
		{
			cmdNext.Enabled = true;
			_activeItem--;
			DisplayItem(_activeItem);
			if (_activeItem == cboPanlIndex.SelectedIndex) cmdPrev.Enabled = false;
		}

		private void numItemX_ValueChanged(object sender, EventArgs e)
		{
			if (!_loading)
			{
				_cockpit.Layouts[cboItems.SelectedIndex].X = (short)numItemX.Value;
				pctMask.Invalidate();
			}
		}
		private void numItemY_ValueChanged(object sender, EventArgs e)
		{
			if (!_loading)
			{
				_cockpit.Layouts[cboItems.SelectedIndex].Y = (short)numItemY.Value;
				pctMask.Invalidate();
			}
		}
		private void numVar1_ValueChanged(object sender, EventArgs e)
		{
			if (!_loading)
			{
				_cockpit.Layouts[cboItems.SelectedIndex].Argument1 = Convert.ToByte(numVar1.Value);
				pctMask.Invalidate();
			}
		}
		private void numVar2_ValueChanged(object sender, EventArgs e)
		{
			if (!_loading)
			{
				_cockpit.Layouts[cboItems.SelectedIndex].Argument2 = Convert.ToByte(numVar2.Value);
				pctMask.Invalidate();
			}
		}

		private void optDisplay_CheckedChanged(object sender, EventArgs e)
		{
			pctMask.Invalidate();
		}
		private void optLaserRight_CheckedChanged(object sender, EventArgs e)
		{
			_cockpit.Layouts[cboItems.SelectedIndex].Argument2 = Convert.ToByte(optLaserRight.Checked);
		}
		#endregion
	}
}
