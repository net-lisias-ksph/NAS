# NAS - Naval Artillery System :: Change Log

* 2017-1105: 0.6.6.1 (Acea) for KSP 1.3.1
	+ 0.6.6.1 (FIX) - "Our Freedom"
		- Updated plugin to adapt to KSP 1.3.1 and latest BDArmory Continued.
		- Retextured Tallboy 12,000 lb Earthquake Bomb.
		- Redefined all radars for new BDAc features (now they consume ElectricCharge).
		- Stopped redistributing C.A.L++ since all ammos have been merged into BDAc.
		- Minor changes in Japanese and Spanish descriptions.
		- Inherited 1-01A Universal Ammunition Box and BDExplosiveTweakScale.cfg from C.A.L++, old users could still use them.
		- FuMO 61 "Hohentwiel U" radar can no longer lock targets.
		- Corrected size of two Bofors 40 mm L/60's (Mark 4 Quad Mount & QF 40 mm Mk I Mount).
		- Added a custom part category for NAS parts.
* 2017-1001: 0.6.6 (Acea) for KSP 1.3.0
	+ 0.6.6 (IMPORTANT) - "Our Freedom"
		- Updated plugin to adapt to latest BDArmory Continued.
		- Minor changes in Chinese descriptions and weapon type of depth charges.
		- Added target engaging settings for Guard Mode.
		- Added 1 new part:
		- US Navy: Bofors 40 mm L/60 (Mark 4 Quad Mount)
* 2017-0702: 0.6.5.2 (Acea) for KSP 1.3.0
	+ 0.6.5.2 (FIX) - "Crossroads"
	+ Special thanks to forum user Next_Star_Industries ,for his help with Russian localization!*
		- Tweaked size of torpedo/DC settings UI.
		- Significantly optimized gun and torpedo sound effects (which caused slightly larger file sizes).
		- Rechecked existing localization files and corrected a few spelling mistakes.
		- Added localization support to Russian.
* 2017-0625: 0.6.5.1 (Acea) for KSP 1.3.0
	+ 0.6.5.1 (FIX) - "Crossroads"
	+ Special thanks to forum user fitiales, for his Spanish localization texts!*
		- Updated part list.
		- Tweaked overheating rate of 10 cm/65 Type 98 Naval Gun.
		- Tweaked deviation angles of all guns (once which were too accurate) to make them more realistic and still somehow player-friendly, based on following rules:
		- Any medium to large caliber weapon (larger than 75 mm) would have a deviation that would match the average length of the same class ships at the edge of effective range.
		- Side cannons, except 15.5 cm/60 3rd Year Type Naval Gun Triple Turret (cruiser gun), would use a destroyer template, large caliber AA guns use 2/3 of maximum range as effective range.
		- Fixed localization path of 28 cm SK C/28 Twin Turret.
		- Added localization support to Spanish.
* 2017-0617: 0.6.5 (Acea) for KSP 1.3.0
	+ 0.6.5 (IMPORTANT) - "Crossroads"
	+ Special thanks to forum user eboshi, who greatly helped with localization progress of NAS!*
		- Updated plugins for compatibility with KSP 1.3, and added the function of setting depths of all torpedoes/depth charges on board (UI localized in simplified Chinese and Japanese).
		- Updated to latest C.A.L++.
		- Tweaked Fritz X Guided Anti-ship Glide Bomb so it can work more smoothly.
		- Removed LoadingTipsPlus configuring file.
		- Rebalanced small caliber AA weapons, now they should be about 1/3 less powerful, and buffed range of Type 96 25 mm AT/AA Gun Triple Mount.
		- Overhauled all the tags, now it would be easier to search any parts.
		- Applied new exhaust effects to all torpedoes/rockets and Fritz X, now they behave normal.
		- Applied armor piercing settings to CA/BB guns, and rebalanced their powers.
		- Added localization support to simplified Chinese and Japanese. Sorry that we only have speakers of these two languages among our team members and volunteers, please help us with all these untranslated texts.
		- Added 2 new parts:
		- Kriegsmarine: 28 cm SK C/28 Twin Turret
		- US Army: 14-inch M1909 Twin Turret (Fort Drum Type)
* 2017-0217: 0.6.0.6 (Acea) for KSP 1.2.2
	+ 0.6.0.6 (FIX) - "Naval Holiday"
		- Updated plugins for full compatibility with KSP 1.2.2.
		- Updated to latest C.A.L++.
		- Fixed a model glitch of Oerlikon 20 mm L70 Cannon Mk 20 Twin Mount.
* 2016-1202: 0.6.0.5 (Acea) for KSP 1.2.1
	+ 0.6.0.5 (FIX) - "Naval Holiday"
		- Fixed an issue which made Type 91 Torpedo Mod 2 "Thunder Fish" staying still in water.
		- Fixed an issue which caused depth charges to explode instantly after being dropped.
* 2016-1103: 0.6.0 (Acea) for KSP 1.2.1
	+ 0.6.0 (IMPORTANT) - "Naval Holiday"
	+ Thanks to TheBeardyPenguin & TAPEGaming on YouTube, for their awesome Fall Of Kerbin series and multiple battle tests in actual game, which greatly helped us improve NAS!
		- Updated plugins for compatibility with KSP 1.2 (old plugins would still work with new/modified parts if you're running 1.1.x).
		- Updated to latest C.A.L++.
		- Tweaked rotating speed of 610 mm Torpedo Launcher.
		- Tweaked lift settings of unguided rockets.
		- Tweaked launching speeds and crash tolerances of torpedoes so they can be ejected like real ones.
		- Tweaked explosion model sizes of cruiser cannon shells.
		- Tweaked blasting radii of most cannon shells (blasting powers have not been modified) for reality.
		- Simplified BDA short names of a few turrets.
		- Reverted some description changes in 0.5.5 due to a font issue in new version.
		- Renamed the single US 5" gun as 5"/38 cal Mk 12 Naval Gun Mark 30 Turret.
		- Removed the dummy NAS toolbar icon, ASWeapon folder and ATM config file.
		- Removed air burst setting of Type 96 25 mm AT/AA Gun Triple Mount rounds.
		- Reduced blasting radii of depth charges for reality and safety.
		- Reduced ammo storage of all main/secondary turrets to 20 shots (e.g. 60 rounds for a triple turret), which can be extended with universal ammo box or the new magazine part.
		- Redistributed source code of ASW.dll in the package.
		- Provided a complete part list.
		- Optimized textures and converted all normal maps to DDS format under a new method.
		- Modified particle texture of Tiny Tim Unguided Rocket and Type 93 Torpedo "Long Lance".
		- Corrected short name of 3.7 cm SK C/30 Anti-aircraft Gun Dual Mount and Type 96 25 mm AT/AA Gun Triple Mount.
		- Corrected description and exhausting effect of Tiny Tim Unguided Rocket.
		- Corrected attaching node and mass center of 12.7 cm/50 cal Type 3 Naval Gun Dual Mount Turret.
		- Added longer pauses to torpedo launchers after firing the last torpedo, to make sure all torpedoes go towards target straightly.
		- Added a LoadingTipsPlus configuring file, which included a bunch of custom loading tips.
		- Added 3 new parts:
		- US Navy: 12"/50 caliber Gun Mark 8 Triple Turret, AN-Mk 1 1,600 lb Armor Piercing Bomb
		- Misc: ETM-1 Universal Extended Naval Magazine
* 2016-0909: 0.5.5.7 (Acea) for KSP 0.7.3
	+ 0.5.5.7/F (HOTFIX) - "Lend-Lease Act"
	+ Fixed ammo type definition of 3-inch Naval Gun Mount Mark 21.
* 2016-0806: 0.5.0.5 (Acea) for KSP 0.7.3
	+ 0.5.0.5 (HOTFIX) - "Red Star over Oceans"
	+ Temporary solution to ASW plugin spamming log files. (Toolbar button is a
	+ placeholder)
	+ Strengthened joint of 41 cm/45 3rd Year Type Naval Gun.
	+ Fixed wrong size of 37 mm/67 66-K Automatic Anti-aircraft Gun Turret, 3.7 cm
	+ SK C/30 Anti-aircraft Gun Dual Mount, Bofors 40 mm Dual Mount, Dual M2HB Mount
	+ and Oerlikon 20 mm Dual Mount.
	+ Fixed accuracy settings of most guns.
	+ Added weapon manager module to STEN Mk. II Submachine Gun.
* 2016-0320: 0.4.0 (Acea) for KSP 0.7.3
	+ 0.4.0 (IMPORTANT) - "Atlantic Epic"
	+ Updated C.A.L++ to 0.1.0 (with all existing ammo boxes deprecated).
	+ Slightly improved anti-aircraft weapon muzzle fire effects.
	+ Removed the old fake Mark 14 torpedo launcher.
	+ Redistributed the Firespitter plugin by Snjo for the new universal ammo box in
	+ C.A.L++.
	+ Redid model of 20.3 cm SK/C 34.
	+ Most light anti-aircraft guns now contain their own ammunitions. (Amounts may
	+ Fixed an issue that some bombs bounce on the water surface.
	+ Changed guidance mode of Fritz X to beam riding.
	+ Applied a temporary buoyancy to torpedoes before we have a specific guidance.
	+ Added 8 new parts:
		- Kriegsmarine: 10.5 cm SK C/33 Naval Gun
		- Les Forces Navales Francaises Libres (Free French Naval Forces): Canon de
	+ 138 mm Modele 1934 Twin Turret
		- Regia Marina: Cannone da 381/50 Ansaldo M1934, 90 mm/50 (3.5") Ansaldo
	+ Model 1938, Cannone-Mitragliera da 37/54 (Breda) Model 1932
		- Royal Navy: BL 14 inch Mk VII Naval Gun Quadruple Mount, QF 2-pounder
		- Pom-pom" Mark VIA Mount
			- US Navy: Mark 15 Torpedo (launcher would come in next patch due to some
	+ issues)
* 2016-0215: 0.3.6 (Acea) for KSP 0.7.3
	+ 0.3.6 (IMPORTANT) - "Imperial Fleet"
	+ Thanks harpwner for his excellent work on muzzle fire effects!
	+ Updated C.A.L++ to 0.0.8.
	+ Reduced accuracy of small caliber anti-aircraft guns.
	+ Redefined all gun powers according to new BDArmory definition.
	+ New particle effects applied on most naval guns.
	+ Fixed the stack node of Vickers 14 inch turret.
	+ Fixed buoyancy of all parts.
	+ Extended maximum air detonation ranges.
	+ Damage calculation now uses formula below:
	+ [P = cannonShellPower ≈ 6 * m^(0.4) (m stands for the shell's TNT equivalent
	+ of bursting charge, kg)(Recommending 7.5 * m^(0.4) for 75 to 155 mm gun)]
	+ [H = cannonShellHeat ≈ 10.5 * m^(0.4) (Recommending 13.125 * m^(0.4) for 75 to
	+ 155 mm gun)]
	+ [R = cannonShellRadius ≈ 21 * m^(0.8) (Recommending 4.2 * m^(0.8) or 8.4 *
	+ m^(0.8) for medium to large caliber cannons)]
	+ Added 3 new parts:
				- Imperial Japanese Navy: 14 cm/50 3rd Year Type Naval Gun, Type 93 "Long
	+ Lance" Torpedo, 610 mm Torpedo Tube Quad Mount
