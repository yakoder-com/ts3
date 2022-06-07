// Decompiled with JetBrains decompiler
// Type: Sims3.SimIFace.BuildBuy.BuildBuyProduct

using Sims3.SimIFace.CustomContent;
using System;

namespace Sims3.SimIFace.BuildBuy
{
  public class BuildBuyProduct : IDisposable, IComparable, IExportableContent, IMetaTagExporter
  {
    protected uint mHandle;

    internal uint Handle
    {
      get
      {
        return this.mHandle;
      }
    }

    public BuildBuyProduct(uint handle)
    {
      this.mHandle = handle;
    }

    ~BuildBuyProduct()
    {
      this.Dispose(true);
    }

    public string CatalogName
    {
      get
      {
        return UserToolUtils.GetProductCatalogName(this);
      }
    }

    public ulong CatalogNameKey
    {
      get
      {
        return UserToolUtils.GetProductCatalogNameKey(this);
      }
    }

    public string Description
    {
      get
      {
        return UserToolUtils.GetProductDescription(this);
      }
    }

    public float Price
    {
      get
      {
        return UserToolUtils.GetProductPrice(this);
      }
    }

    public bool ShowInCatalog
    {
      get
      {
        return ((int) UserToolUtils.GetProductStatusFlag(this) & 1) != 0;
      }
    }

    public bool IsVisibleInWorldBuilder
    {
      get
      {
        return UserToolUtils.GetIsVisibleInWorldBuilder(this);
      }
    }

    public uint StatusFlag
    {
      get
      {
        return UserToolUtils.GetProductStatusFlag(this);
      }
    }

    public ResourceKey ProductResourceKey
    {
      get
      {
        return UserToolUtils.GetProductResourceKey(this);
      }
    }

    public ResourceKey ModelResourceKey
    {
      get
      {
        return UserToolUtils.GetProductModelResourceKey(this);
      }
    }

    public ResourceKey ProxyCatalogObjectKey
    {
      get
      {
        return UserToolUtils.GetProxyCatalogObjectResourceKey(this);
      }
    }

    public float EnvironmentScore
    {
      get
      {
        return UserToolUtils.GetProductEnvironmentScore(this);
      }
    }

    public uint GetProductCategory(UserToolUtils.BuildBuyProductType type)
    {
      return UserToolUtils.GetProductCategory(this, type);
    }

    public uint FireType
    {
      get
      {
        return UserToolUtils.GetProductFireType(this);
      }
    }

    public bool IsStealable
    {
      get
      {
        return UserToolUtils.GetProductIsStealable(this);
      }
    }

    public bool CanBeReposesed
    {
      get
      {
        return UserToolUtils.GetProductIsReposesable(this);
      }
    }

    public uint ProductSetID
    {
      get
      {
        return UserToolUtils.GetProductSetID(this);
      }
    }

    public uint NumLevels
    {
      get
      {
        return UserToolUtils.GetProductNumLevels(this);
      }
    }

    public uint RoomTypeFlags
    {
      get
      {
        return UserToolUtils.GetProductRoomTypeFlags(this);
      }
    }

    public uint BuyCategoryFlags
    {
      get
      {
        return UserToolUtils.GetProductBuyCategoryFlags(this);
      }
    }

    public ulong BuySubCategoryFlags
    {
      get
      {
        return UserToolUtils.GetProductBuySubCategoryFlags(this);
      }
    }

    public ulong BuySubCategory2Flags
    {
      get
      {
        return UserToolUtils.GetProductBuySubCategory2Flags(this);
      }
    }

    public ulong BuyRoomSubCategoryFlags
    {
      get
      {
        return UserToolUtils.GetProductBuyRoomSubCategoryFlags(this);
      }
    }

    public uint BuildCategoryFlags
    {
      get
      {
        return UserToolUtils.GetProductBuildCategoryFlags(this);
      }
    }

    public BuildBuyProduct.eWallFlags WallPlacementFlags
    {
      get
      {
        return (BuildBuyProduct.eWallFlags) UserToolUtils.GetWallPlacementFlags(this);
      }
    }

    public bool IsWallObject
    {
      get
      {
        return BuildBuyProduct.eWallFlags.kWFAnywhere != (this.WallPlacementFlags & BuildBuyProduct.eWallFlags.kWFOnWall);
      }
    }

    public BuildBuyProduct.ePatternType PatternType
    {
      get
      {
        return (BuildBuyProduct.ePatternType) UserToolUtils.GetProductPatternType(this);
      }
    }

    public uint PatternSubsort
    {
      get
      {
        return UserToolUtils.GetProductPatternSubsort(this);
      }
    }

    public string ObjectInstanceName
    {
      get
      {
        return UserToolUtils.GetProductObjectInstanceName(this);
      }
    }

    public ResourceKeyContentCategory ContentCategory
    {
      get
      {
        return DownloadContent.GetContentCategory(this.ProductResourceKey);
      }
    }

    public uint NumPresets
    {
      get
      {
        return UserToolUtils.ProductNumPresets(this);
      }
    }

    public bool HasUserPreset
    {
      get
      {
        return UserToolUtils.ProductHasUserPreset(this);
      }
    }

    public bool IsPagodaRoof
    {
      get
      {
        return UserToolUtils.ProductIsPagodaRoof(this);
      }
    }

    public bool IsAColumn
    {
      get
      {
        return ((int) this.BuildCategoryFlags & 16) != 0;
      }
    }

    public bool CanPetSitUnder
    {
      get
      {
        return !UserToolUtils.GetPetsCannotSitUnder(this);
      }
    }

    public bool CanPetJumpOn
    {
      get
      {
        return !UserToolUtils.GetPetsCannotJumpOn(this);
      }
    }

    public bool CanLargeAnimalUse
    {
      get
      {
        return !UserToolUtils.GetLargeAnimalsCannotUse(this);
      }
    }

    public bool IsBuildableShell
    {
      get
      {
        return UserToolUtils.GetIsBuildableShell(this);
      }
    }

    public bool IsGiftable
    {
      get
      {
        return UserToolUtils.GetIsGiftable(this);
      }
    }

    public BuildBuyPreset PresetAtIndex(uint index)
    {
      uint presetID = UserToolUtils.ProductPresetIdAtIndex(this, index);
      if (presetID != uint.MaxValue)
        return new BuildBuyPreset(this, presetID);
      return (BuildBuyPreset) null;
    }

    public BuildBuyPreset PresetWithId(uint presetId)
    {
      if (presetId != uint.MaxValue)
        return new BuildBuyPreset(this, presetId);
      return (BuildBuyPreset) null;
    }

    public BuildBuyPreset PresetMatchingString(
      string presetStr,
      bool bAllowApproxMatch)
    {
      return this.PresetWithId(UserToolUtils.GetPresetIdFromProductAndString(this.mHandle, presetStr, bAllowApproxMatch));
    }

    public bool CheckObjectPlacement(UserToolUtils.BuildBuyProductType checkForType)
    {
      return UserToolUtils.CheckObjectPlacement(this, checkForType);
    }

    public bool IsBlueprint
    {
      get
      {
        return ((int) this.BuildCategoryFlags & 268435456) != 0;
      }
    }

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      BuildBuyProduct buildBuyProduct = obj as BuildBuyProduct;
      if ((object) buildBuyProduct == null)
        return false;
      return (int) this.Handle == (int) buildBuyProduct.Handle;
    }

    public override int GetHashCode()
    {
      return (int) this.Handle;
    }

    public static bool operator ==(BuildBuyProduct a, BuildBuyProduct b)
    {
      if (object.ReferenceEquals((object) a, (object) b))
        return true;
      if ((object) a == null || (object) b == null)
        return false;
      return (int) a.Handle == (int) b.Handle;
    }

    public static bool operator !=(BuildBuyProduct a, BuildBuyProduct b)
    {
      return !(a == b);
    }

    private void Dispose(bool fromDtor)
    {
      if (this.mHandle != 0U)
      {
        UserToolUtils.DestroyProduct(this);
        this.mHandle = 0U;
      }
      if (fromDtor)
        return;
      GC.SuppressFinalize((object) this);
    }

    public int CompareTo(object obj)
    {
      BuildBuyProduct buildBuyProduct = obj as BuildBuyProduct;
      if (!(buildBuyProduct != (BuildBuyProduct) null))
        return 0;
      int num = this.CatalogName.CompareTo(buildBuyProduct.CatalogName);
      if (num != 0)
        return num;
      ResourceKey productResourceKey1 = this.ProductResourceKey;
      ResourceKey productResourceKey2 = buildBuyProduct.ProductResourceKey;
      if (productResourceKey1 == productResourceKey2)
        return 0;
      if ((int) productResourceKey1.TypeId != (int) productResourceKey2.TypeId)
        return productResourceKey1.TypeId >= productResourceKey2.TypeId ? 1 : -1;
      if ((long) productResourceKey1.InstanceId != (long) productResourceKey2.InstanceId)
        return productResourceKey1.InstanceId >= productResourceKey2.InstanceId ? 1 : -1;
      return productResourceKey1.GroupId >= productResourceKey2.GroupId ? 1 : -1;
    }

    public virtual void Dispose()
    {
      this.Dispose(false);
    }

    public bool ExportContent(
      ResKeyTable resKeyTable,
      ObjectIdTable objIdTable,
      IPropertyStreamWriter writer)
    {
      resKeyTable.AddKey(this.ProductResourceKey);
      return true;
    }

    public bool ImportContent(
      ResKeyTable resKeyTable,
      ObjectIdTable objIdTable,
      IPropertyStreamReader reader)
    {
      return true;
    }

    public bool ExportMetaTags(IPropertyStreamWriter writer)
    {
      if (writer == null)
        return false;
      writer.WriteString(3663119981U, this.CatalogName);
      writer.WriteString(1918277202U, this.Description);
      writer.WriteFloat(3159956723U, this.Price);
      return true;
    }

    public enum eStatusFlag
    {
      kFlagShowInCatalog = 1,
      kFlagProductForTesting = 2,
      kFlagProductInDevelopment = 4,
      kFlagShippingProduct = 8,
      kFlagDebugProduct = 16, // 0x00000010
      kFlagProductionProduct = 32, // 0x00000020
      kFlagObjProductMadeUsingNewEntryScheme = 64, // 0x00000040
    }

    public enum eRoomType : uint
    {
      kRoomTypeLivingRoom = 2,
      kRoomTypeDiningRoom = 4,
      kRoomTypeKitchen = 8,
      kRoomTypeKidsRoom = 16, // 0x00000010
      kRoomTypeBathroom = 32, // 0x00000020
      kRoomTypeBedRoom = 64, // 0x00000040
      kRoomTypeStudy = 128, // 0x00000080
      kRoomTypeOutdoors = 256, // 0x00000100
      kRoomTypeCommunityLot = 512, // 0x00000200
      kRoomTypeResidentialLot = 1024, // 0x00000400
      kRoomTypePool = 2048, // 0x00000800
      kRoomTypeFountain = 4096, // 0x00001000
      kRoomTypeResortLobby = 8192, // 0x00002000
      kRoomTypeResortSpa = 16384, // 0x00004000
      kRoomTypeResortGym = 32768, // 0x00008000
      kRoomTypeResortRestaurant = 65536, // 0x00010000
      kRoomTypeResortTikiLounge = 131072, // 0x00020000
      kRoomTypeResortArcade = 262144, // 0x00040000
      kRoomTypeResortArtGallery = 524288, // 0x00080000
      kRoomTypeResortDanceHall = 1048576, // 0x00100000
      kRoomTypeResortOutdoorPartyArea = 2097152, // 0x00200000
      kRoomTypeResortPoolArea = 4194304, // 0x00400000
      kRoomTypeDefault = 2147483648, // 0x80000000
      kRoomTypeAll = 4294967295, // 0xFFFFFFFF
    }

    public enum eBuyCategory : uint
    {
      kBuyCategoryAppliances = 2,
      kBuyCategoryElectronics = 4,
      kBuyCategoryEntertainment = 8,
      kBuyCategoryLighting = 32, // 0x00000020
      kBuyCategoryPlumbing = 64, // 0x00000040
      kBuyCategoryDecor = 128, // 0x00000080
      kBuyCategoryKids = 256, // 0x00000100
      kBuyCategoryStorage = 512, // 0x00000200
      kBuyCategoryComfort = 2048, // 0x00000800
      kBuyCategorySurfaces = 4096, // 0x00001000
      kBuyCategoryVehicles = 8192, // 0x00002000
      kBuyCategoryPets = 16384, // 0x00004000
      kBuyCategoryShowStage = 32768, // 0x00008000
      kBuyCategoryResort = 65536, // 0x00010000
      kBuyCategoryNormal = 1073741823, // 0x3FFFFFFF
      kBuyCategoryDebug = 1073741824, // 0x40000000
      kBuyCategoryDefault = 2147483648, // 0x80000000
      kBuyCategoryAll = 4294967295, // 0xFFFFFFFF
    }

    public enum eBuySubCategory : ulong
    {
      kBuySubCategoryMiscellaneousAppliances = 2,
      kBuySubCategorySmallAppliances = 4,
      kBuySubCategoryLargeAppliances = 8,
      kBuySubCategoryTombObjects = 16, // 0x0000000000000010
      kBuySubCategoryFishSpawners = 32, // 0x0000000000000020
      kBuySubCategoryPlantsAndSeedSpawners = 64, // 0x0000000000000040
      kBuySubCategoryTVs = 128, // 0x0000000000000080
      kBuySubCategoryMiscellaneousElectronics = 256, // 0x0000000000000100
      kBuySubCategoryRockGemMetalSpawners = 512, // 0x0000000000000200
      kBuySubCategoryAudio = 1024, // 0x0000000000000400
      kBuySubCategoryComputers = 2048, // 0x0000000000000800
      kBuySubCategoryHobbiesAndSkills = 4096, // 0x0000000000001000
      kBuySubCategorySportingGoods = 8192, // 0x0000000000002000
      kBuySubCategoryLivingChairs = 16384, // 0x0000000000004000
      kBuySubCategoryHorses = 32768, // 0x0000000000008000
      kBuySubCategoryInsectSpawners = 65536, // 0x0000000000010000
      kBuySubCategoryParties = 131072, // 0x0000000000020000
      kBuySubCategoryMiscellaneousEntertainment = 262144, // 0x0000000000040000
      kBuySubCategoryCeilingLights = 524288, // 0x0000000000080000
      kBuySubCategoryFloorLamps = 1048576, // 0x0000000000100000
      kBuySubCategoryTableLamps = 2097152, // 0x0000000000200000
      kBuySubCategoryWallLamps = 4194304, // 0x0000000000400000
      kBuySubCategoryOutdoorLights = 8388608, // 0x0000000000800000
      kBuySubCategoryLoungeChairs = 16777216, // 0x0000000001000000
      kBuySubCategorySinks = 33554432, // 0x0000000002000000
      kBuySubCategoryToilets = 67108864, // 0x0000000004000000
      kBuySubCategoryShowersAndTubs = 134217728, // 0x0000000008000000
      kBuySubCategoryMiscellaneousDecor = 268435456, // 0x0000000010000000
      kBuySubCategorySculptures = 536870912, // 0x0000000020000000
      kBuySubCategoryPaintingsAndPosters = 1073741824, // 0x0000000040000000
      kBuySubCategoryPlants = 2147483648, // 0x0000000080000000
      kBuySubCategoryMirrors = 4294967296, // 0x0000000100000000
      kBuySubCategoryDogs = 8589934592, // 0x0000000200000000
      kBuySubCategoryMiscObjects = 17179869184, // 0x0000000400000000
      kBuySubCategoryBookshelves = 34359738368, // 0x0000000800000000
      kBuySubCategoryDisplays = 68719476736, // 0x0000001000000000
      kBuySubCategoryDressers = 137438953472, // 0x0000002000000000
      kBuySubCategoryDiningChairs = 274877906944, // 0x0000004000000000
      kBuySubCategorySofasAndLoveseats = 549755813888, // 0x0000008000000000
      kBuySubCategoryMiscellaneousComfort = 1099511627776, // 0x0000010000000000
      kBuySubCategoryRoofDecorations = 2199023255552, // 0x0000020000000000
      kBuySubCategoryBeds = 4398046511104, // 0x0000040000000000
      kBuySubCategoryDebug = 8796093022208, // 0x0000080000000000
      kBuySubCategoryCoffeeTables = 17592186044416, // 0x0000100000000000
      kBuySubCategoryCounters = 35184372088832, // 0x0000200000000000
      kBuySubCategoryDesks = 70368744177664, // 0x0000400000000000
      kBuySubCategoryEndTables = 140737488355328, // 0x0000800000000000
      kBuySubCategoryDiningTables = 281474976710656, // 0x0001000000000000
      kBuySubCategoryFurniture = 562949953421312, // 0x0002000000000000
      kBuySubCategoryToys = 1125899906842624, // 0x0004000000000000
      kBuySubCategoryCars = 2251799813685248, // 0x0008000000000000
      kBuySubCategoryBicycles = 4503599627370496, // 0x0010000000000000
      kBuySubCategoryCabinets = 9007199254740992, // 0x0020000000000000
      kBuySubCategoryCurtainsAndBlinds = 18014398509481984, // 0x0040000000000000
      kBuySubCategoryMiscellaneousKids = 36028797018963968, // 0x0080000000000000
      kBuySubCategoryMiscellaneousLighting = 72057594037927936, // 0x0100000000000000
      kBuySubCategoryMiscellaneousPlumbing = 144115188075855872, // 0x0200000000000000
      kBuySubCategoryMiscellaneousStorage = 288230376151711744, // 0x0400000000000000
      kBuySubCategoryMiscellaneousSurfaces = 576460752303423488, // 0x0800000000000000
      kBuySubCategoryMiscellaneousVehicles = 1152921504606846976, // 0x1000000000000000
      kBuySubCategoryMiscellaneous = 2269815311975055618, // 0x1F80010010040102
      kBuySubCategoryRugs = 2305843009213693952, // 0x2000000000000000
      kBuySubCategoryCats = 4611686018427387904, // 0x4000000000000000
      kBuySubCategoryDefault = 9223372036854775808, // 0x8000000000000000
      kBuySubCategoryAll = 18446744073709551615, // 0xFFFFFFFFFFFFFFFF
    }

    public enum eBuySubCategory2 : ulong
    {
      kBuySubCategory2FXandLights = 2,
      kBuySubCategory2Props = 4,
      kBuySubCategory2Misc = 8,
      kBuySubCategory2Miscellaneous = 8,
      kBuySubCategory2UnderwaterObjects = 16, // 0x0000000000000010
      kBuySubCategory2ResortMisc = 32, // 0x0000000000000020
      kBuySubCategory2Boats = 64, // 0x0000000000000040
      kBuySubCategory2Default = 9223372036854775808, // 0x8000000000000000
      kBuySubCategory2All = 18446744073709551615, // 0xFFFFFFFFFFFFFFFF
    }

    public enum eBuyRoomSubCategory : ulong
    {
      kBuyRoomSubCategoryDishwashers = 2,
      kBuyRoomSubCategorySmallAppliances = 4,
      kBuyRoomSubCategoryRefrigerators = 8,
      kBuyRoomSubCategoryDisposal = 16, // 0x0000000000000010
      kBuyRoomSubCategoryAlarms = 32, // 0x0000000000000020
      kBuyRoomSubCategoryPhones = 64, // 0x0000000000000040
      kBuyRoomSubCategoryTVs = 128, // 0x0000000000000080
      kBuyRoomSubCategorySmokeAlarms = 256, // 0x0000000000000100
      kBuyRoomSubCategoryAudio = 1024, // 0x0000000000000400
      kBuyRoomSubCategoryComputers = 2048, // 0x0000000000000800
      kBuyRoomSubCategoryHobbiesAndSkills = 4096, // 0x0000000000001000
      kBuyRoomSubCategoryIndoorActivities = 8192, // 0x0000000000002000
      kBuyRoomSubCategoryLivingChairs = 16384, // 0x0000000000004000
      kBuyRoomSubCategoryOfficeChairs = 32768, // 0x0000000000008000
      kBuyRoomSubCategoryStoves = 65536, // 0x0000000000010000
      kBuyRoomSubCategoryEatingOut = 131072, // 0x0000000000020000
      kBuyRoomSubCategoryOutdoorActivities = 262144, // 0x0000000000040000
      kBuyRoomSubCategoryCeilingLights = 524288, // 0x0000000000080000
      kBuyRoomSubCategoryFloorLamps = 1048576, // 0x0000000000100000
      kBuyRoomSubCategoryTableLamps = 2097152, // 0x0000000000200000
      kBuyRoomSubCategoryWallLamps = 4194304, // 0x0000000000400000
      kBuyRoomSubCategoryOutdoorLights = 8388608, // 0x0000000000800000
      kBuyRoomSubCategoryShowers = 16777216, // 0x0000000001000000
      kBuyRoomSubCategorySinks = 33554432, // 0x0000000002000000
      kBuyRoomSubCategoryToilets = 67108864, // 0x0000000004000000
      kBuyRoomSubCategoryTubs = 134217728, // 0x0000000008000000
      kBuyRoomSubCategoryAccents = 268435456, // 0x0000000010000000
      kBuyRoomSubCategoryLawnOrnaments = 536870912, // 0x0000000020000000
      kBuyRoomSubCategoryPaintingsAndPostersForGrownUps = 1073741824, // 0x0000000040000000
      kBuyRoomSubCategoryPlants = 2147483648, // 0x0000000080000000
      kBuyRoomSubCategoryMirrors = 4294967296, // 0x0000000100000000
      kBuyRoomSubCategoryVideoGames = 8589934592, // 0x0000000200000000
      kBuyRoomSubCategoryPaintingsAndPostersForKids = 17179869184, // 0x0000000400000000
      kBuyRoomSubCategoryBookshelves = 34359738368, // 0x0000000800000000
      kBuyRoomSubCategoryCabinets = 68719476736, // 0x0000001000000000
      kBuyRoomSubCategoryDressers = 137438953472, // 0x0000002000000000
      kBuyRoomSubCategoryDiningChairs = 274877906944, // 0x0000004000000000
      kBuyRoomSubCategorySofasAndLoveseats = 549755813888, // 0x0000008000000000
      kBuyRoomSubCategoryOutdoorSeating = 1099511627776, // 0x0000010000000000
      kBuyRoomSubCategoryRoofDecorations = 2199023255552, // 0x0000020000000000
      kBuyRoomSubCategoryBeds = 4398046511104, // 0x0000040000000000
      kBuyRoomSubCategoryBarStools = 8796093022208, // 0x0000080000000000
      kBuyRoomSubCategoryCoffeeTables = 17592186044416, // 0x0000100000000000
      kBuyRoomSubCategoryCounters = 35184372088832, // 0x0000200000000000
      kBuyRoomSubCategoryDesks = 70368744177664, // 0x0000400000000000
      kBuyRoomSubCategoryEndTables = 140737488355328, // 0x0000800000000000
      kBuyRoomSubCategoryDiningTables = 281474976710656, // 0x0001000000000000
      kBuyRoomSubCategoryFurniture = 562949953421312, // 0x0002000000000000
      kBuyRoomSubCategoryToys = 1125899906842624, // 0x0004000000000000
      kBuyRoomSubCategoryTransportation = 2251799813685248, // 0x0008000000000000
      kBuyRoomSubCategoryBars = 4503599627370496, // 0x0010000000000000
      kBuyRoomSubCategoryClocks = 9007199254740992, // 0x0020000000000000
      kBuyRoomSubCategoryCurtainsAndBlinds = 18014398509481984, // 0x0040000000000000
      kBuyRoomSubCategoryKidsDecor = 36028797018963968, // 0x0080000000000000
      kBuyRoomSubCategoryMiscellaneousDecor = 72057594037927936, // 0x0100000000000000
      kBuyRoomSubCategoryRugs = 144115188075855872, // 0x0200000000000000
      kBuyRoomSubCategoryLaundry = 288230376151711744, // 0x0400000000000000
      kBuyRoomSubCategoryPets = 576460752303423488, // 0x0800000000000000
      kBuyRoomSubCategorySets = 1152921504606846976, // 0x1000000000000000
      kBuyRoomSubCategoryDefault = 9223372036854775808, // 0x8000000000000000
      kBuyRoomSubCategoryAll = 18446744073709551615, // 0xFFFFFFFFFFFFFFFF
    }

    public enum eBuildCategory : uint
    {
      kBuildCategoryDoor = 2,
      kBuildCategoryWindow = 4,
      kBuildCategoryGate = 8,
      kBuildCategoryColumn = 16, // 0x00000010
      kBuildCategoryRabbitHole = 32, // 0x00000020
      kBuildCategoryFireplace = 64, // 0x00000040
      kBuildCategoryChimney = 128, // 0x00000080
      kBuildCategoryArch = 256, // 0x00000100
      kBuildCategoryFlower = 512, // 0x00000200
      kBuildCategoryShrub = 1024, // 0x00000400
      kBuildCategoryTree = 2048, // 0x00000800
      kBuildCategoryRug = 4096, // 0x00001000
      kBuildCategoryRock = 8192, // 0x00002000
      kBuildCategoryShell = 16384, // 0x00004000
      kBuildCategoryMiscObject = 32768, // 0x00008000
      kBuildCategoryElevator = 65536, // 0x00010000
      kBuildCategorySpiralStairscase = 131072, // 0x00020000
      kBuildCategoryTubeElevators = 262144, // 0x00040000
      kBuildCategoryBlueprint = 268435456, // 0x10000000
      kBuildCategoryResortObjects = 536870912, // 0x20000000
      kBuildCategoryModularArch = 1073741824, // 0x40000000
      kBuildCategoryDefault = 2147483648, // 0x80000000
      kBuildCategoryAllButBlueprintsAndResorts = 3489660927, // 0xCFFFFFFF
      kBuildCategoryAllButBlueprintsAndBuildings = 4026531807, // 0xEFFFFFDF
      kBuildCategoryAllButBlueprints = 4026531839, // 0xEFFFFFFF
      kBuildCategoryAll = 4294967295, // 0xFFFFFFFF
    }

    [Flags]
    public enum eWallFlags
    {
      kWFAnywhere = 0,
      kWFMinX = 1,
      kWFMinZ = 2,
      kWFMaxX = 4,
      kWFMaxZ = 8,
      kWF01To10Diag = 16, // 0x00000010
      kWF00To11Diag = 32, // 0x00000020
      kWFRequiredMask = kWF00To11Diag | kWF01To10Diag | kWFMaxZ | kWFMaxX | kWFMinZ | kWFMinX, // 0x0000003F
      kWFNotMinX = 64, // 0x00000040
      kWFNotMinZ = 128, // 0x00000080
      kWFNotMaxX = 256, // 0x00000100
      kWFNotMaxZ = 512, // 0x00000200
      kWFNot01To10Diag = 1024, // 0x00000400
      kWFNot00To11Diag = 2048, // 0x00000800
      kWFNotRequiredMask = kWFNot00To11Diag | kWFNot01To10Diag | kWFNotMaxZ | kWFNotMaxX | kWFNotMinZ | kWFNotMinX, // 0x00000FC0
      kWFFlagsApplyToFences = 4096, // 0x00001000
      kWFProhibitsFenceArch = 8192, // 0x00002000
      kWFOnWall = 16384, // 0x00004000
      kWFIntersectsObjectsOffWall = 32768, // 0x00008000
      kWFApplyCutoutDiagonalShift = 65536, // 0x00010000
      kWFCanBeMovedUpDownOnWall = 131072, // 0x00020000
      kWFCannotBeMovedUpDownOnWall = 262144, // 0x00040000
    }

    public enum ePatternType : uint
    {
      Undefined,
      Floor,
      Wall,
      Ceiling,
      FloorEdge,
    }

    public enum eWallPatternSubsort : uint
    {
      Miscellaneous = 2,
      Masonry = 4,
      Paint = 8,
      Paneling = 16, // 0x00000010
      Rock_Stone = 32, // 0x00000020
      Siding = 64, // 0x00000040
      Tile = 128, // 0x00000080
      Wallpaper = 256, // 0x00000100
      WallSets = 512, // 0x00000200
      All = 4294967295, // 0xFFFFFFFF
    }

    public enum eFloorPatternSubsort : uint
    {
      Miscellaneous = 2,
      Carpet = 4,
      Linoleum = 8,
      Masonry = 16, // 0x00000010
      Metal = 32, // 0x00000020
      Rock_Stone = 64, // 0x00000040
      Tile = 128, // 0x00000080
      Wood = 256, // 0x00000100
      CeilingTile = 512, // 0x00000200
      All = 4294967295, // 0xFFFFFFFF
    }
  }
}
