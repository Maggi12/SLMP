using System.IO;

namespace SLMPLauncher
{
    public class FuncSettings
    {
        public static void LowPreset()
        {
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMultiSample", "1");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxAnisotropy", "16");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iTexMipMapSkip", "2");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fLightLODStartFade", "200.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iShadowMapResolution", "512");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fShadowBiasScale", "0.5000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iBlurDeferredShadowMask", "0");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "bFXAAEnabled", "0");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fMeshLODLevel2FadeDist", "5000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fMeshLODLevel1FadeDist", "5000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fTreesMidLODSwitchDist", "3500.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fShadowDistance", "2000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxDecalsPerFrame", "0");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxSkinDecalsPerFrame", "0");

            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "LOD", "fLODFadeOutMultActors", "2.5000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "LOD", "fLODFadeOutMultObjects", "2.5000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "LOD", "fLODFadeOutMultItems", "1.0000");

            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fTreeLoadDistance", "12500.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fBlockMaximumDistance", "75000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fBlockLevel1Distance", "25000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fBlockLevel0Distance", "15000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fSplitDistanceMult", "0.4000");

            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Grass", "fGrassStartFadeDistance", "1000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Grass", "iMinGrassSize", "70");

            FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODLand", "0");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODObjects", "0");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODTrees", "0");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectSky", "1");

            FuncParser.iniWrite(FormMain.iniSkyrim, "Decals", "bDecals", "0");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Decals", "bSkinnedDecals", "0");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Decals", "uMaxSkinDecals", "0");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Decals", "uMaxSkinDecalsPerActor", "0");
            ENBCheck(false);
        }
        public static void MediumPreset()
        {
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMultiSample", "1");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxAnisotropy", "16");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iTexMipMapSkip", "1");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fLightLODStartFade", "1000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iShadowMapResolution", "1024");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fShadowBiasScale", "0.3000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iBlurDeferredShadowMask", "2");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "bFXAAEnabled", "1");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fMeshLODLevel2FadeDist", "100000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fMeshLODLevel1FadeDist", "100000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fTreesMidLODSwitchDist", "5000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fShadowDistance", "3500.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxDecalsPerFrame", "10");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxSkinDecalsPerFrame", "3");

            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "LOD", "fLODFadeOutMultActors", "5.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "LOD", "fLODFadeOutMultObjects", "3.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "LOD", "fLODFadeOutMultItems", "3.5000");

            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fTreeLoadDistance", "25000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fBlockMaximumDistance", "100000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fBlockLevel1Distance", "32768.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fBlockLevel0Distance", "20480.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fSplitDistanceMult", "0.7500");

            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Grass", "fGrassStartFadeDistance", "3000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Grass", "iMinGrassSize", "60");

            FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODLand", "1");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODObjects", "0");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODTrees", "0");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectSky", "1");

            FuncParser.iniWrite(FormMain.iniSkyrim, "Decals", "bDecals", "1");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Decals", "bSkinnedDecals", "1");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Decals", "uMaxSkinDecals", "35");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Decals", "uMaxSkinDecalsPerActor", "20");
            ENBCheck(false);
        }
        public static void HightPreset()
        {
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMultiSample", "4");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxAnisotropy", "16");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iTexMipMapSkip", "0");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fLightLODStartFade", "2500.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iShadowMapResolution", "2048");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fShadowBiasScale", "0.2500");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iBlurDeferredShadowMask", "3");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "bFXAAEnabled", "1");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fMeshLODLevel2FadeDist", "10000000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fMeshLODLevel1FadeDist", "10000000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fTreesMidLODSwitchDist", "10000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fShadowDistance", "5000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxDecalsPerFrame", "30");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxSkinDecalsPerFrame", "10");

            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "LOD", "fLODFadeOutMultActors", "8.5000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "LOD", "fLODFadeOutMultObjects", "10.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "LOD", "fLODFadeOutMultItems", "7.0000");

            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fTreeLoadDistance", "40000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fBlockMaximumDistance", "150000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fBlockLevel1Distance", "40000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fBlockLevel0Distance", "25000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fSplitDistanceMult", "1.1000");

            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Grass", "fGrassStartFadeDistance", "5000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Grass", "iMinGrassSize", "55");

            FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODLand", "1");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODObjects", "1");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODTrees", "0");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectSky", "1");

            FuncParser.iniWrite(FormMain.iniSkyrim, "Decals", "bDecals", "1");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Decals", "bSkinnedDecals", "1");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Decals", "uMaxSkinDecals", "50");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Decals", "uMaxSkinDecalsPerActor", "40");
            ENBCheck(false);
        }
        public static void UltraPreset()
        {
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMultiSample", "8");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxAnisotropy", "16");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iTexMipMapSkip", "0");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fLightLODStartFade", "3500.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iShadowMapResolution", "4096");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fShadowBiasScale", "0.1500");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iBlurDeferredShadowMask", "3");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "bFXAAEnabled", "1");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fMeshLODLevel2FadeDist", "10000000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fMeshLODLevel1FadeDist", "10000000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fTreesMidLODSwitchDist", "10000000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "fShadowDistance", "8000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxDecalsPerFrame", "100");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxSkinDecalsPerFrame", "25");

            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "LOD", "fLODFadeOutMultActors", "15.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "LOD", "fLODFadeOutMultObjects", "15.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "LOD", "fLODFadeOutMultItems", "15.0000");

            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fTreeLoadDistance", "75000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fBlockMaximumDistance", "250000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fBlockLevel1Distance", "70000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fBlockLevel0Distance", "35000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "TerrainManager", "fSplitDistanceMult", "1.5000");

            FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Grass", "fGrassStartFadeDistance", "7000.0000");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Grass", "iMinGrassSize", "50");

            FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODLand", "1");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODObjects", "1");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectLODTrees", "1");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Water", "bReflectSky", "1");

            FuncParser.iniWrite(FormMain.iniSkyrim, "Decals", "bDecals", "1");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Decals", "bSkinnedDecals", "1");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Decals", "uMaxSkinDecals", "100");
            FuncParser.iniWrite(FormMain.iniSkyrim, "Decals", "uMaxSkinDecalsPerActor", "60");
            ENBCheck(false);
        }
        public static void ENBCheck(bool fromENBMenu)
        {
            if (File.Exists(FormMain.gameFolder + "d3d9.dll"))
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxAnisotropy", "1");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMultiSample", "1");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "bFXAAEnabled", "0");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "bFloatPointRenderTarget", "1");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Display", "bAllowScreenshot", "0");
            }
            else if (fromENBMenu)
            {
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMaxAnisotropy", "16");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "iMultiSample", "1");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "bFXAAEnabled", "1");
                FuncParser.iniWrite(FormMain.iniSkyrimPrefs, "Display", "bFloatPointRenderTarget", "0");
                FuncParser.iniWrite(FormMain.iniSkyrim, "Display", "bAllowScreenshot", "1");
            }
            if (FuncParser.stringRead(FormMain.iniSkyrimPrefs, "Display", "bFull Screen") == "0")
            {
                FuncParser.iniWrite(FormENBMenu.enbLocal, "WINDOW", "ForceBorderless", "true");
            }
            else
            {
                FuncParser.iniWrite(FormENBMenu.enbLocal, "WINDOW", "ForceBorderless", "false");
            }
        }
    }
}