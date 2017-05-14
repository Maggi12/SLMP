using System;
using System.Collections.Generic;
using System.IO;

namespace SLMPLauncher
{
    public static class FuncClear
    {
        static SortedSet<string> CustomIgnoreList = new SortedSet<string>(StringComparer.OrdinalIgnoreCase);
        static SortedSet<string> IgnoreListFiles = new SortedSet<string>(StringComparer.OrdinalIgnoreCase) {
            @"atimgpud.dll",
            @"binkw32.dll",
            @"d3d9.dll",
            @"enbhost.exe",
            @"enblocal.ini",
            @"enbseries.ini",
            @"skse_1_9_32.dll",
            @"skse_steam_loader.dll",
            @"SKYRIM.exe",
            @"steam_api.dll",
            @"TESV.exe",
            @"Data\1nivWICCloaks.bsa",
            @"Data\1nivWICCloaks.esp",
            @"Data\AcquisitiveSoulGem.bsa",
            @"Data\AcquisitiveSoulGem.esp",
            @"Data\AHZmoreHUD.bsa",
            @"Data\AHZmoreHUD.esp",
            @"Data\AlternateStart.bsa",
            @"Data\AlternateStart.esp",
            @"Data\AlwaysPickUpBooks.bsa",
            @"Data\AlwaysPickUpBooks.esp",
            @"Data\AMatterOfTime.bsa",
            @"Data\AMatterOfTime.esp",
            @"Data\Audio Overhaul.bsa",
            @"Data\Audio Overhaul.esp",
            @"Data\BFSEffects.bsa",
            @"Data\BFSEffects.esp",
            @"Data\Blacksmith Chests.bsa",
            @"Data\Blacksmith Chests.esp",
            @"Data\Book Covers Skyrim.bsa",
            @"Data\Book Covers Skyrim.esp",
            @"Data\Books Of Skyrim.bsa",
            @"Data\Books Of Skyrim.esp",
            @"Data\Campfire.bsa",
            @"Data\Campfire.esm",
            @"Data\ChangeFollowerOutfits.bsa",
            @"Data\ChangeFollowerOutfits.esp",
            @"Data\Wearable Lantern.bsa",
            @"Data\Wearable Lantern.esp",
            @"Data\ClimatesOfTamriel.bsa",
            @"Data\ClimatesOfTamriel.esp",
            @"Data\Cloaks.bsa",
            @"Data\Cloaks.esp",
            @"Data\ClothingWeaponClutter.bsa",
            @"Data\ClothingWeaponClutter.esp",
            @"Data\CoinPurse.bsa",
            @"Data\CoinPurse.esp",
            @"Data\Customizable Camera.bsa",
            @"Data\Customizable Camera.esp",
            @"Data\Cutting Room Floor.bsa",
            @"Data\Cutting Room Floor.esp",
            @"Data\Dawnguard.esm",
            @"Data\Enhanced Blood.bsa",
            @"Data\Enhanced Blood.esp",
            @"Data\DeadlySpellImpacts.bsa",
            @"Data\DeadlySpellImpacts.esp",
            @"Data\DestructibleBottles.bsa",
            @"Data\DestructibleBottles.esp",
            @"Data\Dragonborn.esm",
            @"Data\Dragon Souls.bsa",
            @"Data\Dragon Souls.esp",
            @"Data\Dual Sheath Redux Patch.esp",
            @"Data\Dual Sheath Redux.bsa",
            @"Data\Dual Sheath Redux.esp",
            @"Data\Dual Wield Parrying.bsa",
            @"Data\Dual Wield Parrying.esp",
            @"Data\Dynamic Depth of Field.bsa",
            @"Data\Dynamic Depth of Field.esp",
            @"Data\EarsTails.bsa",
            @"Data\EarsTails.esp",
            @"Data\ENBvision.bsa",
            @"Data\ENBvision.esp",
            @"Data\EnhancedLightsFX.bsa",
            @"Data\EnhancedLightsFX.esp",
            @"Data\FaceMasksOfSkyrim.bsa",
            @"Data\FaceMasksOfSkyrim.esp",
            @"Data\Faction Crossbows.bsa",
            @"Data\Faction Crossbows.esp",
            @"Data\Falskaar.bsa",
            @"Data\Falskaar.esp",
            @"Data\F N I S.bsa",
            @"Data\F N I S.esp",
            @"Data\Follower Commentary.bsa",
            @"Data\Follower Commentary.esp",
            @"Data\Footprints.bsa",
            @"Data\Footprints.esp",
            @"Data\Frostfall.bsa",
            @"Data\Frostfall.esp",
            @"Data\GameComm.bsa",
            @"Data\GameMesh1.bsa",
            @"Data\GameMesh2.bsa",
            @"Data\GameMesh3.bsa",
            @"Data\GameText1.bsa",
            @"Data\GameText2.bsa",
            @"Data\GameText3.bsa",
            @"Data\GameText4.bsa",
            @"Data\GameText5.bsa",
            @"Data\GameText6.bsa",
            @"Data\GameText7.bsa",
            @"Data\GameText8.bsa",
            @"Data\GameVoice1.bsa",
            @"Data\GameVoice2.bsa",
            @"Data\getSnowy.bsa",
            @"Data\getSnowy.esp",
            @"Data\GuardDialogueOverhaul.bsa",
            @"Data\GuardDialogueOverhaul.esp",
            @"Data\HDT Earring.bsa",
            @"Data\HDT Earring.esp",
            @"Data\HDT Hairs.bsa",
            @"Data\HDT Hairs.esp",
            @"Data\Headtracking.bsa",
            @"Data\Headtracking.esp",
            @"Data\HearthFires.esm",
            @"Data\HelmetToggle.bsa",
            @"Data\HelmetToggle.esp",
            @"Data\HorseInventory.bsa",
            @"Data\HorseInventory.esp",
            @"Data\Huntsman.bsa",
            @"Data\Huntsman.esp",
            @"Data\iHUD.bsa",
            @"Data\iHUD.esp",
            @"Data\Immersive Citizens.bsa",
            @"Data\Immersive Citizens.esp",
            @"Data\iNeed - DD.esp",
            @"Data\iNeed.bsa",
            @"Data\iNeed.esp",
            @"Data\Interiors Furniture Fix.bsa",
            @"Data\Interiors Furniture Fix.esp",
            @"Data\InvisEyeFixes.bsa",
            @"Data\InvisEyeFixes.esp",
            @"Data\JaxonzMapMarkers.bsa",
            @"Data\JaxonzMapMarkers.esp",
            @"Data\JSwords.bsa",
            @"Data\JSwords.esp",
            @"Data\Landscape Improved.bsa",
            @"Data\Landscape Improved.esp",
            @"Data\Left Hand Rings.bsa",
            @"Data\Left Hand Rings.esp",
            @"Data\Leveled Enemy.esp",
            @"Data\Leveled Items.esp",
            @"Data\LootAndDegradation.bsa",
            @"Data\LootAndDegradation.esp",
            @"Data\LoreWeaponExpansion.bsa",
            @"Data\LoreWeaponExpansion.esp",
            @"Data\Naked.bsa",
            @"Data\Naked.esp",
            @"Data\NIOVHH.bsa",
            @"Data\NIOVHH.esp",
            @"Data\Open Helmet.bsa",
            @"Data\Open Helmet.esp",
            @"Data\Ordinator.bsa",
            @"Data\Ordinator.esp",
            @"Data\OSAsex.bsa",
            @"Data\OSAsex.esp",
            @"Data\Quests Markers.bsa",
            @"Data\Quests Markers.esp",
            @"Data\RaceMenu.bsa",
            @"Data\RaceMenu.esp",
            @"Data\RitualArmorofBoethiah.bsa",
            @"Data\RitualArmorofBoethiah.esp",
            @"Data\Skyforge Weapon.bsa",
            @"Data\Skyforge Weapon.esp",
            @"Data\Skyrim.esm",
            @"Data\SkyUI.bsa",
            @"Data\SkyUI.esp",
            @"Data\TradeBarter.bsa",
            @"Data\TradeBarter.esp",
            @"Data\Tunic.bsa",
            @"Data\Tunic.esp",
            @"Data\Unique Uniques.bsa",
            @"Data\Unique Uniques.esp",
            @"Data\UniqueBorderGates.bsa",
            @"Data\UniqueBorderGates.esp",
            @"Data\Unofficial Skyrim Legendary Edition Patch.bsa",
            @"Data\Unofficial Skyrim Legendary Edition Patch.esp",
            @"Data\Update.bsa",
            @"Data\Update.esm",
            @"Data\FloraRespawnFix.bsa",
            @"Data\FloraRespawnFix.esp",
            @"Data\WondersofWeather.bsa",
            @"Data\WondersofWeather.esp",
            @"Data\Wyrmstooth.bsa",
            @"Data\Wyrmstooth.esp",
            @"Data\Meshes\animationsetdatasinglefile.SAVE",
            @"Data\Meshes\animationsetdatasinglefile.txt",
            @"Data\Meshes\Actors\Character\Character Assets\skeleton.hkx",
            @"Data\Meshes\Actors\Character\Character Assets Female\skeleton_female.hkx",
            @"Data\Meshes\Actors\Character\Characters\defaultmale.hkx",
            @"Data\Meshes\Actors\Character\Characters Female\defaultfemale.hkx",
            @"Data\Scripts\FNISVersionGenerated.pex",
            @"Data\Scripts\FNIS_aa.pex",
            @"Data\Scripts\FNIS_aa2.pex",
            @"Data\SKSE\SKSE.ini",
            @"Data\SKSE\Plugins\AHZmoreHUDPlugin.dll",
            @"Data\SKSE\Plugins\BugFixPlugin.dll",
            @"Data\SKSE\Plugins\BugFixPlugin.ini",
            @"Data\SKSE\Plugins\chargen.dll",
            @"Data\SKSE\Plugins\chargen.ini",
            @"Data\SKSE\Plugins\CPConvert.dll",
            @"Data\SKSE\Plugins\CPConvert.ini",
            @"Data\SKSE\Plugins\CrashFixPlugin.dll",
            @"Data\SKSE\Plugins\CrashFixPlugin.ini",
            @"Data\SKSE\Plugins\EnchantReloadFix.dll",
            @"Data\SKSE\Plugins\hdtPhysicsExtensions.dll",
            @"Data\SKSE\Plugins\hdtPhysicsExtensions.ini",
            @"Data\SKSE\Plugins\hdtPhysicsExtensionsDefaultBBP.xml",
            @"Data\SKSE\Plugins\hdtPhysicsExtensionsDefaultBBP_ORIG.xml",
            @"Data\SKSE\Plugins\hdtSittingHeightFix.dll",
            @"Data\SKSE\Plugins\hdtSittingHeightFix_AnimationList.txt",
            @"Data\SKSE\Plugins\hdtSkyrimMemPatch.dll",
            @"Data\SKSE\Plugins\hdtSkyrimMemPatch.ini",
            @"Data\SKSE\Plugins\MfgConsole.dll",
            @"Data\SKSE\Plugins\MfgConsole.ini",
            @"Data\SKSE\Plugins\nioverride.dll",
            @"Data\SKSE\Plugins\nioverride.ini",
            @"Data\SKSE\Plugins\OSA.dll",
            @"Data\SKSE\Plugins\ru_fix.dll",
            @"Data\SKSE\Plugins\SKSE_EnhancedCamera.dll",
            @"Data\SKSE\Plugins\SKSE_EnhancedCamera.ini",
            @"Data\SKSE\Plugins\skse_russian_helper.dll",
            @"Data\SKSE\Plugins\StorageUtil.dll",
            @"Data\SKSE\Plugins\ToggleWalkRunFix.dll",
            @"Data\SkyProc Patchers\Dual Sheath Redux Patch\Dual Sheath Redux Patch.jar",
            @"Data\Video\Falskaar_Intro.bik",
            @"Data\Video\Falskaar_Outro.bik",
            @"Skyrim\Skyrim.ini",
            @"Skyrim\SkyrimPrefs.ini",
            @"Skyrim\SLMPIgnoreFiles.ini",
            @"Skyrim\SLMPLauncher.exe",
            @"Skyrim\SLMPLauncher.ini",
            @"Skyrim\UnRAR.exe"
        };
        static SortedSet<string> IgnoreListFolders = new SortedSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            @"Data",
            @"Data\Meshes",
            @"Data\Meshes\0SA",
            @"Data\Meshes\0SP",
            @"Data\Meshes\Actors",
            @"Data\Meshes\Actors\Character",
            @"Data\Meshes\Actors\Character\Animations",
            @"Data\Meshes\Actors\Character\Behaviors",
            @"Data\Meshes\Actors\Character\Character Assets",
            @"Data\Meshes\Actors\Character\Character Assets Female",
            @"Data\Meshes\Actors\Character\Characters",
            @"Data\Meshes\Actors\Character\Characters Female",
            @"Data\Meshes\Armor",
            @"Data\Meshes\Armor\Chesko",
            @"Data\Meshes\Armor\Naked",
            @"Data\Meshes\Armor\Tails",
            @"Data\Meshes\Armor\WeaponSling",
            @"Data\Meshes\Clothes",
            @"Data\Meshes\Clothes\Cloaks",
            @"Data\Meshes\Clothes\HorseCloak",
            @"Data\Meshes\Clothes\HDT Test Earring",
            @"Data\Meshes\Hair",
            @"Data\Meshes\Hair\Clark",
            @"Data\Meshes\Hair\Fuse00Hair",
            @"Data\Meshes\Hair\Havok Physx",
            @"Data\Meshes\Hair\HDT Untitled Hairs",
            @"Data\Meshes\Hair\HHairstyles",
            @"Data\Meshes\Hair\KS Hairdo's",
            @"Data\Meshes\Hair\Skyrim HDT Hair",
            @"Data\Meshes\Hair\Yoo",
            @"Data\Scripts",
            @"Data\SKSE",
            @"Data\SKSE\Plugins",
            @"Data\SKSE\Plugins\CharGen",
            @"Data\SKSE\Plugins\FrostfallData",
            @"Data\SKSE\Plugins\CampfireData",
            @"Data\SKSE\Plugins\WearableLanternsData",
            @"Data\SkyProc Patchers",
            @"Data\SkyProc Patchers\Dual Sheath Redux Patch",
            @"Data\Tools",
            @"Data\Tools\GenerateFNIS_for_Users",
            @"Data\Video",
            @"ENBSeries",
            @"Logs",
            @"Skyrim",
            @"Skyrim\CPFiles",
            @"Skyrim\ENB",
            @"Skyrim\LangVoice",
            @"Skyrim\MasterList",
            @"_Programs"
        };
        static SortedSet<string> MainFoldersIngoredList = new SortedSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            @"_Programs",
            @"ENBSeries",
            @"Logs",
            @"Skyrim\CPFiles",
            @"Skyrim\ENB",
            @"Skyrim\LangVoice",
            @"Skyrim\MasterList",
            @"Data\Meshes\0SA",
            @"Data\Meshes\0SP",
            @"Data\Meshes\Actors\Character\Animations",
            @"Data\Meshes\Actors\Character\Behaviors",
            @"Data\Meshes\Armor\Chesko",
            @"Data\Meshes\Armor\Naked",
            @"Data\Meshes\Armor\Tails",
            @"Data\Meshes\Armor\WeaponSling",
            @"Data\Meshes\Clothes\Cloaks",
            @"Data\Meshes\Clothes\HorseCloak",
            @"Data\Meshes\Clothes\HDT Test Earring",
            @"Data\Meshes\Hair\Clark",
            @"Data\Meshes\Hair\Fuse00Hair",
            @"Data\Meshes\Hair\Havok Physx",
            @"Data\Meshes\Hair\HDT Untitled Hairs",
            @"Data\Meshes\Hair\HHairstyles",
            @"Data\Meshes\Hair\KS Hairdo's",
            @"Data\Meshes\Hair\Skyrim HDT Hair",
            @"Data\Meshes\Hair\Yoo",
            @"Data\SKSE\Plugins\CampfireData",
            @"Data\SKSE\Plugins\CharGen",
            @"Data\SKSE\Plugins\FrostfallData",
            @"Data\SKSE\Plugins\WearableLanternsData",
            @"Data\Tools\GenerateFNIS_for_Users"
        };
        public static void Clear()
        {
            if (File.Exists(FormMain.launcherFolder + "SLMPIgnoreFiles.ini"))
            {
                CustomIgnoreList.Clear();
                CustomIgnoreList.UnionWith(File.ReadAllLines(FormMain.launcherFolder + "SLMPIgnoreFiles.ini"));
            }
            else
            {
                CustomIgnoreList.Clear();
            }
            if (Directory.Exists(FormMain.gameFolder))
            {
                ClearCurrentFolder("");
                SearthAllForders(FormMain.gameFolder);
            }
        }
        static void SearthAllForders(string startLocation)
        {
            if (Directory.Exists(startLocation))
            {
                foreach (string line in Directory.EnumerateDirectories(startLocation))
                {
                    string folderName = line.Remove(0, FormMain.gameFolder.Length);
                    if (folderName.Length > 0)
                    {
                        if (!MainFoldersIngoredList.Contains(folderName) && !CustomIgnoreList.Contains(folderName))
                        {
                            SearthAllForders(line);
                            ClearCurrentFolder(folderName);
                        }
                    }
                }
            }
        }
        static void ClearCurrentFolder(string clearpath)
        {
            if (Directory.Exists(FormMain.gameFolder + clearpath))
            {
                foreach (string line in Directory.EnumerateFiles(FormMain.gameFolder + clearpath))
                {
                    string fileName = line.Remove(0, FormMain.gameFolder.Length);
                    if (!IgnoreListFiles.Contains(fileName) && !CustomIgnoreList.Contains(fileName))
                    {
                        FuncFiles.Delete(line);
                    }
                }
                foreach (string line in Directory.EnumerateDirectories(FormMain.gameFolder + clearpath))
                {
                    string dirName = line.Remove(0, FormMain.gameFolder.Length);
                    if (!IgnoreListFolders.Contains(dirName) && !CustomIgnoreList.Contains(dirName))
                    {
                        FuncFiles.Delete(line);
                    }
                }
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static void EmptyFolder(string path)
        {
            if (Directory.Exists(path))
            {
                foreach (string line in Directory.GetDirectories(path))
                {
                    EmptyFolder(line);
                    if (Directory.GetFiles(line).Length == 0 && Directory.GetDirectories(line).Length == 0)
                    {
                        FuncFiles.Delete(line);
                    }
                }
            }
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static void ENB()
        {
            FuncFiles.Delete(FormMain.gameFolder + "CINEMATIC");
            FuncFiles.Delete(FormMain.gameFolder + "CR-Enb.dll");
            FuncFiles.Delete(FormMain.gameFolder + "Custom_LUT1.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "Custom_LUT2.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "Custom_LUT3.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "EED_verasansmono.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "ELEP Additional Shaders");
            FuncFiles.Delete(FormMain.gameFolder + "ENBInjector.exe");
            FuncFiles.Delete(FormMain.gameFolder + "Enbpalettes");
            FuncFiles.Delete(FormMain.gameFolder + "EnhancedENBDiagnostics.fxh");
            FuncFiles.Delete(FormMain.gameFolder + "FXAA_Tool.exe");
            FuncFiles.Delete(FormMain.gameFolder + "FixForBrightObjects.txt");
            FuncFiles.Delete(FormMain.gameFolder + "Headers");
            FuncFiles.Delete(FormMain.gameFolder + "LUT_1.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "LUT_10.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "LUT_11.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "LUT_12.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "LUT_2.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "LUT_3.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "LUT_4.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "LUT_5.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "LUT_6.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "LUT_7.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "LUT_8.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "LUT_9.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "SMAA.fx");
            FuncFiles.Delete(FormMain.gameFolder + "SMAA.h");
            FuncFiles.Delete(FormMain.gameFolder + "SMAA_DX11.fx");
            FuncFiles.Delete(FormMain.gameFolder + "STRONG WARM");
            FuncFiles.Delete(FormMain.gameFolder + "Shader Functions");
            FuncFiles.Delete(FormMain.gameFolder + "SweetFX");
            FuncFiles.Delete(FormMain.gameFolder + "SweetFX_d3d9.dll");
            FuncFiles.Delete(FormMain.gameFolder + "SweetFX_preset.txt");
            FuncFiles.Delete(FormMain.gameFolder + "SweetFX_settings.txt");
            FuncFiles.Delete(FormMain.gameFolder + "_locationweather.ini");
            FuncFiles.Delete(FormMain.gameFolder + "_mist_anchors.xml");
            FuncFiles.Delete(FormMain.gameFolder + "_sample_enbraindrops");
            FuncFiles.Delete(FormMain.gameFolder + "_weatherlist.ini");
            FuncFiles.Delete(FormMain.gameFolder + "common.fxh");
            FuncFiles.Delete(FormMain.gameFolder + "d3d9.dll");
            FuncFiles.Delete(FormMain.gameFolder + "d3d9.fx");
            FuncFiles.Delete(FormMain.gameFolder + "d3d9SFFiles.dll");
            FuncFiles.Delete(FormMain.gameFolder + "d3d9_FXAA.dll");
            FuncFiles.Delete(FormMain.gameFolder + "d3d9_SFFiles.dll");
            FuncFiles.Delete(FormMain.gameFolder + "d3d9_SFX.dll");
            FuncFiles.Delete(FormMain.gameFolder + "d3d9_SFX_FXAA.dll");
            FuncFiles.Delete(FormMain.gameFolder + "d3d9_SFX_SMAA.dll");
            FuncFiles.Delete(FormMain.gameFolder + "d3d9_Sharpen.dll");
            FuncFiles.Delete(FormMain.gameFolder + "d3d9_SweetFFiles.dll");
            FuncFiles.Delete(FormMain.gameFolder + "d3d9_smaa.dll");
            FuncFiles.Delete(FormMain.gameFolder + "d3d9injFFiles.dll");
            FuncFiles.Delete(FormMain.gameFolder + "d3d9orig.dll");
            FuncFiles.Delete(FormMain.gameFolder + "d3d9swe.dll");
            FuncFiles.Delete(FormMain.gameFolder + "defaultlut.png");
            FuncFiles.Delete(FormMain.gameFolder + "dxgi.dll");
            FuncFiles.Delete(FormMain.gameFolder + "dxgi.fx");
            FuncFiles.Delete(FormMain.gameFolder + "effect.txt");
            FuncFiles.Delete(FormMain.gameFolder + "effect.txt.ini");
            FuncFiles.Delete(FormMain.gameFolder + "enbbloom.fx");
            FuncFiles.Delete(FormMain.gameFolder + "enbbloom.fx.ini");
            FuncFiles.Delete(FormMain.gameFolder + "enbbloom.fx.rar");
            FuncFiles.Delete(FormMain.gameFolder + "enbdefs.fx");
            FuncFiles.Delete(FormMain.gameFolder + "enbdirt.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "enbdirt.tga");
            FuncFiles.Delete(FormMain.gameFolder + "enbeffect.fFiles.ini");
            FuncFiles.Delete(FormMain.gameFolder + "enbeffect.fx");
            FuncFiles.Delete(FormMain.gameFolder + "enbeffect.fx.ini");
            FuncFiles.Delete(FormMain.gameFolder + "enbeffectprepass.fx");
            FuncFiles.Delete(FormMain.gameFolder + "enbeffectprepass.fx.ini");
            FuncFiles.Delete(FormMain.gameFolder + "enbeffectxx.fx.ini");
            FuncFiles.Delete(FormMain.gameFolder + "enbfontunicode.png");
            FuncFiles.Delete(FormMain.gameFolder + "enbfrost.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "enbhelper.dll");
            FuncFiles.Delete(FormMain.gameFolder + "enbhost.exe");
            FuncFiles.Delete(FormMain.gameFolder + "enbinjector.ini");
            FuncFiles.Delete(FormMain.gameFolder + "enblens.fx");
            FuncFiles.Delete(FormMain.gameFolder + "enblens.fx.ini");
            FuncFiles.Delete(FormMain.gameFolder + "enblens1.fx");
            FuncFiles.Delete(FormMain.gameFolder + "enblensmask.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "enblensmask.png");
            FuncFiles.Delete(FormMain.gameFolder + "enblensmask.tga");
            FuncFiles.Delete(FormMain.gameFolder + "enblensmask_16.9.png");
            FuncFiles.Delete(FormMain.gameFolder + "enblensmask_Alternative_Incr Dirt Int.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "enblensmask_Alternative_Incr Dirt Int.tga");
            FuncFiles.Delete(FormMain.gameFolder + "enblensmask_Blue Pentagons Default.tga");
            FuncFiles.Delete(FormMain.gameFolder + "enblensmask_Blue Pentagons.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "enblensmask_Default Bitmap.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "enblensmask_Default.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "enblensmask_Default_Alternative.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "enblensmask_Light Alternative 2.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "enblensmask_Light Alternative.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "enblensmask_Original Default.tga");
            FuncFiles.Delete(FormMain.gameFolder + "enblensmask_Red Pentagons Default.tga");
            FuncFiles.Delete(FormMain.gameFolder + "enblensmask_Softer Alternative.tga");
            FuncFiles.Delete(FormMain.gameFolder + "enblensmask_Softer_Incr Dirt Int.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "enblensmask_Softer_Incr Dirt Int.tga");
            FuncFiles.Delete(FormMain.gameFolder + "enblensmask_anamorphic.png");
            FuncFiles.Delete(FormMain.gameFolder + "enblensmask_square01.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "enblensmask_square02.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "enblensmask_square03.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "enblocal.ini");
            FuncFiles.Delete(FormMain.gameFolder + "enblocalization.xml");
            FuncFiles.Delete(FormMain.gameFolder + "enblut1.png");
            FuncFiles.Delete(FormMain.gameFolder + "enblut2.png");
            FuncFiles.Delete(FormMain.gameFolder + "enblut3.png");
            FuncFiles.Delete(FormMain.gameFolder + "enblut4.png");
            FuncFiles.Delete(FormMain.gameFolder + "enblut5.png");
            FuncFiles.Delete(FormMain.gameFolder + "enblut6.png");
            FuncFiles.Delete(FormMain.gameFolder + "enblut7.png");
            FuncFiles.Delete(FormMain.gameFolder + "enbpalette.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "enbpalette.png");
            FuncFiles.Delete(FormMain.gameFolder + "enbraindrops.tga");
            FuncFiles.Delete(FormMain.gameFolder + "enbseries");
            FuncFiles.Delete(FormMain.gameFolder + "enbseries.dll");
            FuncFiles.Delete(FormMain.gameFolder + "enbseries.ini");
            FuncFiles.Delete(FormMain.gameFolder + "enbseries_Dense Mist_Default.ini");
            FuncFiles.Delete(FormMain.gameFolder + "enbseries_Subtle Mist.ini");
            FuncFiles.Delete(FormMain.gameFolder + "enbseries_mastereffect.ini");
            FuncFiles.Delete(FormMain.gameFolder + "enbspectrum.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "enbsunsprite.fx");
            FuncFiles.Delete(FormMain.gameFolder + "enbsunsprite.fx.ini");
            FuncFiles.Delete(FormMain.gameFolder + "enbsunsprite.tga");
            FuncFiles.Delete(FormMain.gameFolder + "enbsunsprite_Additional.tga");
            FuncFiles.Delete(FormMain.gameFolder + "enbsunsprite_Additional_2.tga");
            FuncFiles.Delete(FormMain.gameFolder + "enbsunsprite_Chroma_Lens.tga");
            FuncFiles.Delete(FormMain.gameFolder + "enbsunsprite_Colored_Hexagons.tga");
            FuncFiles.Delete(FormMain.gameFolder + "enbsunsprite_Exotic_Low_Sprites.tga");
            FuncFiles.Delete(FormMain.gameFolder + "enbsunsprite_High Dispersion.tga");
            FuncFiles.Delete(FormMain.gameFolder + "enbsunsprite_Low Dispersion.tga");
            FuncFiles.Delete(FormMain.gameFolder + "enbsunsprite_MoonSprite.tga");
            FuncFiles.Delete(FormMain.gameFolder + "enbsunsprite_Octagon_Nova_Glare.tga");
            FuncFiles.Delete(FormMain.gameFolder + "enbsunsprite_Pentagons_Medium_Sprites.tga");
            FuncFiles.Delete(FormMain.gameFolder + "enbsunsprite_Rotated.tga");
            FuncFiles.Delete(FormMain.gameFolder + "enbsunsprite_Simple_Hexagons.tga");
            FuncFiles.Delete(FormMain.gameFolder + "enbweather.bmp");
            FuncFiles.Delete(FormMain.gameFolder + "injFX_Settings.h");
            FuncFiles.Delete(FormMain.gameFolder + "injFX_Shaders");
            FuncFiles.Delete(FormMain.gameFolder + "injector.ini");
            FuncFiles.Delete(FormMain.gameFolder + "shader.fx");
            FuncFiles.Delete(FormMain.gameFolder + "shift.dll");
            FuncFiles.Delete(FormMain.gameFolder + "sweetfx_d3d9.dll");
            FuncFiles.Delete(FormMain.gameFolder + "technique.fxh");
            FuncFiles.Delete(FormMain.gameFolder + "volumetric_mist_anchors.xml");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\ENBvision.bsa");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\ENBvision.esp");
        }
        //////////////////////////////////////////////////////ГРАНИЦА ФУНКЦИИ//////////////////////////////////////////////////////////////
        public static void OSA()
        {
            if (File.Exists(FormMain.gameFolder + @"Data\SKSE\Plugins\hdtPhysicsExtensionsDefaultBBP_ORIG.xml"))
            {
                FuncFiles.Delete(FormMain.gameFolder + @"Data\SKSE\Plugins\hdtPhysicsExtensionsDefaultBBP.xml");
                FuncFiles.MoveAnyFiles(FormMain.gameFolder + @"Data\SKSE\Plugins\hdtPhysicsExtensionsDefaultBBP_ORIG.xml", FormMain.gameFolder + @"Data\SKSE\Plugins\hdtPhysicsExtensionsDefaultBBP.xml");
            }
            FuncFiles.Delete(FormMain.gameFolder + @"Data\OSAsex.esp");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\OSAsex.bsa");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Naked.esp");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Naked.bsa");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\SKSE\Plugins\CPConvert.dll");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\SKSE\Plugins\CPConvert.ini");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\SKSE\Plugins\OSA.dll");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Meshes\0SA");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Meshes\0SP");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Meshes\Armor\Naked");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Meshes\Actors\Character\Animations\_ESG_0ER_F");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Meshes\Actors\Character\Animations\_ESG_0ER_M");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Meshes\Actors\Character\Animations\0Sex_0MF_D");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Meshes\Actors\Character\Animations\0Sex_0MF_K");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Meshes\Actors\Character\Animations\0Sex_0MF_M");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Meshes\Actors\Character\Animations\0Sex_0MF_S");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Meshes\Actors\Character\Animations\0Sex_0MF_U");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Meshes\Actors\Character\Animations\0Sex_EMF_A");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Meshes\Actors\Character\Behaviors\FNIS__ESG_0ER_F_Behavior.hkx");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Meshes\Actors\Character\Behaviors\FNIS__ESG_0ER_M_Behavior.hkx");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Meshes\Actors\Character\Behaviors\FNIS_0Sex_0MF_D_Behavior.hkx");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Meshes\Actors\Character\Behaviors\FNIS_0Sex_0MF_K_Behavior.hkx");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Meshes\Actors\Character\Behaviors\FNIS_0Sex_0MF_M_Behavior.hkx");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Meshes\Actors\Character\Behaviors\FNIS_0Sex_0MF_S_Behavior.hkx");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Meshes\Actors\Character\Behaviors\FNIS_0Sex_0MF_U_Behavior.hkx");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Meshes\Actors\Character\Behaviors\FNIS_0Sex_EMF_A_Behavior.hkx");
        }
        public static void TUNIC()
        {
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Tunic.esp");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Tunic.bsa");
        }
        public static void AS()
        {
            FuncFiles.Delete(FormMain.gameFolder + @"Data\AlternateStart.esp");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\AlternateStart.bsa");
        }
        public static void FFC()
        {
            FuncFiles.Delete(FormMain.gameFolder + @"Data\SKSE\Plugins\CampfireData");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\SKSE\Plugins\FrostfallData");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Campfire.esm");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Campfire.bsa");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Frostfall.esp");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Frostfall.bsa");
        }
        public static void INEED()
        {
            FuncFiles.Delete(FormMain.gameFolder + @"Data\iNeed - DD.esp");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\iNeed.esp");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\iNeed.bsa");
        }
        public static void LAD()
        {
            FuncFiles.Delete(FormMain.gameFolder + @"Data\LootAndDegradation.esp");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\LootAndDegradation.bsa");
        }
        public static void ORD()
        {
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Ordinator.esp");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Ordinator.bsa");
        }
        public static void ET()
        {
            FuncFiles.Delete(FormMain.gameFolder + @"Data\EarsTails.esp");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\EarsTails.bsa");
            FuncFiles.Delete(FormMain.gameFolder + @"Data\Meshes\Armor\Tails");
        }
    }
}