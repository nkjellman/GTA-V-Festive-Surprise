using GTA;
using GTA.Native;
using GTA.Math;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

public class FestiveSurprise : Script
{
	ScriptSettings IniSettings;
	bool enableAllYear;
	public FestiveSurprise()
	{
		IniSettings = ScriptSettings.Load("scripts\\FestiveSurprise.ini");
		enableAllYear = IniSettings.GetValue<bool>("Main Configuration", "Enable all year", false);
		
		DateTime today = DateTime.Today;
		var month = today.Month;
		//GTA.Native.Function.Call(GTA.Native.Hash._0xB87A37EEB7FAA67D, "STRING");
        //GTA.Native.Function.Call(GTA.Native.Hash._ADD_TEXT_COMPONENT_STRING, month);
        //GTA.Native.Function.Call(GTA.Native.Hash._0x9D77056A530643F6, 5000, 1);
		if (month == 12 || enableAllYear)
		{
			List<int> Props = new List<int>();
			int LodDistance = 3000;            

			Func<int, Vector3, Vector3, bool, int> createProp = new Func<int, Vector3, Vector3, bool, int>(delegate(int hash, Vector3 pos, Vector3 rot, bool dynamic)
			{
				Model model = new Model(hash);
				model.Request(10000);
				Prop prop = GTA.World.CreateProp(model, pos, rot, dynamic, false);
				prop.Position = pos;
				prop.LodDistance = LodDistance;
				if (!dynamic)
					prop.FreezePosition = true;
				return prop.Handle;
			});
			bool Initialized = false;
		
		

			base.Tick += delegate (object sender, EventArgs args)
			{
				if (!Initialized)
				{
					//michael's rockford hills house
					Props.Add(createProp(238789712, new GTA.Math.Vector3(-801.296936f, 176.470078f, 72.0909653f), new GTA.Math.Vector3(0f, 0f, 10.6025267f), false));
					//franklin's vinewood house
					Props.Add(createProp(238789712, new GTA.Math.Vector3(9.11399746f, 526.248535f, 173.884506f), new GTA.Math.Vector3(0f, 0f, -151.706055f), false));
					//franklin & dinese's strawberry house
					Props.Add(createProp(238789712, new GTA.Math.Vector3(-9.90259266f, -1436.47278f, 30.3578243f), new GTA.Math.Vector3(0f, 0f, -151.124542f), false));
					//floyed & debra's la puerta condo
					Props.Add(createProp(238789712, new GTA.Math.Vector3(-1157.43799f, -1518.62061f, 9.89700794f), new GTA.Math.Vector3(0f, 0f, 99.9997864f), false));
					//downtown los santos
					Props.Add(createProp(118627012, new GTA.Math.Vector3(236.483154f, -880.348022f, 29.4916935f), new GTA.Math.Vector3(0f, 0f, -87.4999847f), false));
					//fib lobby
					Props.Add(createProp(238789712, new GTA.Math.Vector3(110.728912f, -758.928162f, 45.0079231f), new GTA.Math.Vector3(0f, 0f, -170.051285f), false));
					//fib 49th floor
					Props.Add(createProp(238789712, new GTA.Math.Vector3(116.245331f, -735.059937f, 241.408386f), new GTA.Math.Vector3(0f, 0f, 71.806366f), false));
					//life invader 2nd floor
					Props.Add(createProp(238789712, new GTA.Math.Vector3(-1081.94067f, -252.510712f, 43.2774277f), new GTA.Math.Vector3(0f, 0f, 117.280724f), false));
					//life invader lobby
					Props.Add(createProp(238789712, new GTA.Math.Vector3(-1076.04382f, -247.940506f, 37.019558f), new GTA.Math.Vector3(0f, 0f, -30.4778328f), false));

					Initialized = true;
				}
				Prop returnedProp;

			};
		}
	}
}