/*
 * TieCockpitEditor.exe, Cockpit editor for TIE95
 * Copyright (C) 2009 Michael Gaisser (mjgaisser@gmail.com)
 * Licensed under the MPL v2.0 or later
 * 
 * VERSION: 0.9.1
 */

using System;
using System.IO;

namespace Idmr.CockpitEditor
{
	/// <summary>Cockpit information for TIE95</summary>
	class TieInt
	{
		private readonly string _filePath;
		private readonly View[] _views = new View[28];
		#region enums
		public enum ViewIndex { Forward, LeftFore, Left, LeftAft, Aft, RightAft, Right, RightFore, 
			ForeHigh, LeftForeHigh, LeftHigh, LeftAftHigh, AftHigh, RightAftHigh, RightHigh, RightForeHigh,
			Up, Default, Empty, NoCockpit, ThreatDisplay, MissionGoals, InflightMap, MessageLog, DamageLog, 
			WingmanOrders, KeyboardRef, FlightOptions }
		public enum ViewStatus { Present = 0x01, Absent = 0x90, Default, MirrorForward = 0xC0, MirrorLeftFore,
			MirrorLeft, MirrorLeftAft, MirrorAft, MirrorRightAft, MirrorRight, MirrorRightFore, MirrorForedHigh,
			MirrorLeftForeHigh, MirrorLeftHigh, MirrorLeftAftHigh, MirrorAftHigh, MirrorRightAftHigh, MirrorRightHigh,
			MirrorRightForeHigh, MirrorUp, MirrorDefault, MirrorEmpty, MirrorNoCockpit, MirrorThreatDisplay, MirrorMissionGoals,
			MirrorInflightMap, MirrorMessageLog, MirrorDamageLog, MirrorWingmanOrders, MirrorKeyboardRef, MirrorFlightOptions}
		private readonly Layout[] _layouts = new Layout[95];
		public static int[] NumberOfImages = { 0, 0, 0, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 0, 0, 0, 0, 1, 1, 1, 1, 4, 0, 0, 2, 2, 2, 2, 0, 2,
												 0, 0, 0, 9, 5, 5, 5, 5, 5, 5, 5, 5, 5, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0,
												 0, 0, 0, 2, 2, 3, 0, 0, 0, 0, 3, 3, 3, 3, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0,
												 0, 0};
		public enum LayoutIndex { FrontSensors, RearSensors, Cmd, Laser1, Laser2, Laser3, Laser4, Laser5, Laser6, Laser7, Laser8, 
			WarheadLight1, WarheadLight2, WarheadLight3, WarheadLight4, WarheadDigit1, WarheadDigit2, WarheadDigit3, WarheadDigit4,
			ForeInnerShield, ForeOuterShield, AftInnerShield, AftOuterShield, HullStatus, VelocityIndicator, ThrottleIndicator, EnginePower,
			LaserPower, ShieldPower, BeamPower, MissionTime, CameraLight, CameraTime, Unknown1, Unknown2, BeamSegments, HudReticule,
			HudLaser1, HudLaser2, HudLaser3, HudLaser4, HudLaser5, HudLaser6, HudLaser7, HudLaser8, CmdFrame, LeftLaserFrame, RightLaserFrame,
			WarheadCountFrame, BeamFrame, HullShieldFrame, SpeedCameraFrame, FrontSensorFrame, RearSensorFrame, LaserPowerFrame,
			EnginePowerFrame, ShieldPowerFrame, BeamPowerFrame, CmdSystemDigits, CmdDistanceHigh, CmdDistanceLow, CmdShieldDigits,
			CmdHullDigits, CmdCargo, Unknown3, CmdComponent, HudFighterLock, HudStarshipLock, HudWarheadLock, ThreatDisplayName,
			ThreatDisplayCargo, ThreatDisplayDistanceHigh, ThreatDisplayDistanceLow, ThreatDisplayLasers, ThreatDisplayIons,
			ThreatDisplayWarheads, ThreatDisplayBeam, ThreatDisplayShields, ThreatDisplayHull, ThreatDisplayOrders, ThreatDisplayTarget,
			ThreatDisplayDistance, ThreatDisplayTime, DisabledShieldPowerFrame, DisabledBeamPowerFrame, DisabledBeamFrame,
			CmdSystemsString, CmdDistanceString, CmdShieldsString, CmdHullString, CmdTargetString, CmdBeamCharge, Reserved1, Reserved2,
			Reserved3}
		public enum PanlItemIndex { ForeOuterShield, ForeInnerShield, AftInnerShield, AftOuterShield, BeamSegment1, BeamSegment2, BeamSegment3,
			BeamSegment4, BeamSegment5, BeamSegment6, BeamSegment7, BeamSegment8, BeamSegment9, ShieldPwrInactive, ShieldPwrActive,
			LaserPwrInactive, LaserPwrActive, EnginePwrInactive, EnginePwrActive, BeamPwrInactive, BeamPwrActive, WarheadInactive, 
			WarheadActive, WarheadLoading, Unused, LaserLow, LaserMed, LaserHigh, CameraOff, CameraOn, HullHeavyDamage, HullMediumDamage,
			HullNormal, HullDisabled, HudReticuleOff, HudReticuleNormal, HudAquiringLock, HudWarheadReady, HudLaserReady, HudLaser1Off,
			HudLaser1On, HudLaser1Charging, HudLaser1Ready, HudLaser1Red, HudLaser2Off, HudLaser2On, HudLaser2Charging, HudLaser2Ready,
			HudLaser2Red, TDNoLaser, TDLaser, TDLaserActive, TDNoIon, TDIon, TDIonActive, TDNoWarhead, TDWarhead, TDWarheadActive, TDNoBeam,
			TDBeam, TDBeamActive, HudNoFighterLock, HudFighterLock, HudNoStarshipLock, HudStarshipLock, HudNoWarheadLock, HudWarheadLocking,
			HudWarheadLocked, CmdFrame, LeftLaserFrame, RightLaserFrame, WarheadFrame, BeamFrame, HullShieldFrame, SpeedCameraFrame,
			FrontSensorFrame, RearSensorFrame, LaserPowerFrame, EnginePowerFrame, ShieldPowerFrame, BeamPowerFrame, DamagedCmdFrame,
			DamagedLeftLaserFrame, DamagedRightLaserFrame, DamagedWarheadFrame, DamagedBeamFrame,
			DamagedHullShieldFrame, DamagedSpeedCameraFrame, DamagedFrontSensors, DamagedRearSensors, DamagedLaserPowerFrame,
			DamagedEnginePowerFrame, DamagedShieldPowerFrame, DamagedBeamPowerFrame, DisabledShieldPowerFrame, DisabledBeamPowerFrame,
			DisabledBeamFrame, BeamActive, BeamCharging, IonLow, IonMed, IonHigh, Unused2, Unused3 }
		public enum LayoutArgument { None, PanlIndex, Digit, Laser, Warhead, Width, Height }
		public static LayoutArgument[,] LayoutArguments = { {0,0}, {0,0},
															  {LayoutArgument.Width,LayoutArgument.Height},
															  {LayoutArgument.PanlIndex,LayoutArgument.Laser},
															  {LayoutArgument.PanlIndex,LayoutArgument.Laser},
															  {LayoutArgument.PanlIndex,LayoutArgument.Laser},
															  {LayoutArgument.PanlIndex,LayoutArgument.Laser},
															  {LayoutArgument.PanlIndex,LayoutArgument.Laser},
															  {LayoutArgument.PanlIndex,LayoutArgument.Laser},
															  {LayoutArgument.PanlIndex,LayoutArgument.Laser},
															  {LayoutArgument.PanlIndex,LayoutArgument.Laser},
															  {LayoutArgument.PanlIndex,LayoutArgument.Warhead},
															  {LayoutArgument.PanlIndex,LayoutArgument.Warhead},
															  {LayoutArgument.PanlIndex,LayoutArgument.Warhead},
															  {LayoutArgument.PanlIndex,LayoutArgument.Warhead},
															  {LayoutArgument.Digit,0}, {LayoutArgument.Digit,0},
															  {LayoutArgument.Digit,0}, {LayoutArgument.Digit,0},
															  {LayoutArgument.PanlIndex,0}, {LayoutArgument.PanlIndex,0},
															  {LayoutArgument.PanlIndex,0}, {LayoutArgument.PanlIndex,0},
															  {LayoutArgument.PanlIndex,0},
															  {LayoutArgument.Digit,0}, {LayoutArgument.Digit,0},
															  {LayoutArgument.PanlIndex,0}, {LayoutArgument.PanlIndex,0},
															  {LayoutArgument.PanlIndex,0}, {LayoutArgument.PanlIndex,0},
															  {LayoutArgument.Digit,0},
															  {LayoutArgument.PanlIndex,0},
															  {LayoutArgument.Digit,0}, {0,0}, {0,0},
															  {LayoutArgument.PanlIndex,0}, {LayoutArgument.PanlIndex,0},
															  {LayoutArgument.PanlIndex,0}, {LayoutArgument.PanlIndex,0},
															  {LayoutArgument.PanlIndex,0}, {LayoutArgument.PanlIndex,0},
															  {LayoutArgument.PanlIndex,0}, {LayoutArgument.PanlIndex,0},
															  {LayoutArgument.PanlIndex,0}, {LayoutArgument.PanlIndex,0},
															  {LayoutArgument.PanlIndex,0}, {LayoutArgument.PanlIndex,0},
															  {LayoutArgument.PanlIndex,0}, {LayoutArgument.PanlIndex,0},
															  {LayoutArgument.PanlIndex,0}, {LayoutArgument.PanlIndex,0},
															  {LayoutArgument.PanlIndex,0}, {LayoutArgument.PanlIndex,0},
															  {LayoutArgument.PanlIndex,0}, {LayoutArgument.PanlIndex,0},
															  {LayoutArgument.PanlIndex,0}, {LayoutArgument.PanlIndex,0},
															  {LayoutArgument.PanlIndex,0},
															  {LayoutArgument.Digit,0}, {LayoutArgument.Digit,0},
															  {LayoutArgument.Digit,0}, {LayoutArgument.Digit,0},
															  {LayoutArgument.Digit,0}, {0,0}, {0,0}, {0,0},
															  {LayoutArgument.PanlIndex,0}, {LayoutArgument.PanlIndex,0},
															  {LayoutArgument.PanlIndex,0}, {0,0}, {0,0},
															  {LayoutArgument.Digit,0}, {LayoutArgument.Digit,0},
															  {LayoutArgument.PanlIndex,0}, {LayoutArgument.PanlIndex,0},
															  {LayoutArgument.PanlIndex,0}, {LayoutArgument.PanlIndex,0},
															  {LayoutArgument.Digit,0}, {LayoutArgument.Digit,0},
															  {0,0}, {0,0}, {0,0}, {0,0},
															  {LayoutArgument.PanlIndex,0}, {LayoutArgument.PanlIndex,0},
															  {LayoutArgument.PanlIndex,0},
															  {0,0}, {0,0}, {0,0}, {0,0}, {0,0}, {0,0}, {0,0}, {0,0}, {0,0}
														  };
		#endregion
		private string _panel;
		// byte = 0;
		public byte Unknown;
		// byte = 0;
		// eof

		/// <param name="filePath">Full path to cockpit *.INT file</param>
		/// <exception cref="ArgumentException">Thrown when filesize does not match required length</exception>
		public TieInt(string filePath)
		{
			_filePath = filePath;
			using (FileStream stream = File.OpenRead(filePath))
			{
				if (stream.Length != 0x635) throw new ArgumentException("File is not valid TIE95 Cockpit file");
				using (BinaryReader br = new BinaryReader(stream))
				{
					for (int i = 0; i < _views.Length; i++)
					{
						_views[i].Status = (ViewStatus)br.ReadByte();
						_views[i].Lfd = new string(br.ReadChars(8)).Trim('\0');
						stream.Position++;
						_views[i].MaskX = br.ReadInt16();
						_views[i].MaskY = br.ReadInt16();
						_views[i].MaskWidth = br.ReadInt16();
						_views[i].MaskHeight = br.ReadInt16();
						_views[i].YAxis = br.ReadInt16();
						_views[i].Name = new string(br.ReadChars(8)).Trim('\0');
						stream.Position += 8;
					}
					for (int i = 0; i < _layouts.Length; i++)
					{
						_layouts[i].X = br.ReadInt16();
						_layouts[i].Y = br.ReadInt16();
						_layouts[i].Argument1 = br.ReadByte();
						_layouts[i].Argument2 = br.ReadByte();
					}
					_panel = new string(br.ReadChars(8)).Trim('\0');
					stream.Position++;
					Unknown = br.ReadByte();
				}
			}
		}

		public string FileDirectory => _filePath.Substring(0, _filePath.LastIndexOf("\\") + 1);
		public string FileName => _filePath.Substring(_filePath.LastIndexOf("\\") + 1);
		public View[] Views => _views;
		public Layout[] Layouts => _layouts;
		/// <summary>Gets or Sets 8 char filename (.PNL extension implied) of Panel data</summary>
		public string Panel
		{
			get => _panel;
			set => _panel = value.Length > 8 ? value.Substring(0, 8) : value;
		}

		public struct View
		{
			public ViewStatus Status;
			private string _lfd;
			public short MaskX;
			public short MaskY;
			public short MaskWidth;
			public short MaskHeight;
			public short YAxis;
			private string _name;
			// long _magic = 0;

			public string Lfd
			{
				get => _lfd;
				set => _lfd = value.Length > 8 ? value.Substring(0, 8) : value;
			}
			public string Name
			{
				get => _name;
				set => _name = value.Length > 8 ? value.Substring(0, 8) : value;
			}
		}
		public struct Layout
		{
			public short X;
			public short Y;
			public byte Argument1;
			public byte Argument2;
		}
	}
}
