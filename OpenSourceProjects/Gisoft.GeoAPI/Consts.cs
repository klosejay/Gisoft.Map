internal static class Consts
{
    public const string Title = "Gisoft.GeoAPI";
    public const string Description = "Gisoft.GeoAPI";
    public const string Company = "Gisoft.NetTopologySuite - Team";
    public const string Copyright = "Copyright © Gisoft.NetTopologySuite - Team 2007-2017";
    public const bool ComVisible = false;
    public const bool CLSCompliant = true;

    private const string FullFrameworkGuid = "b6726fc4-0319-4a6d-84f5-aafc6ba530e3";

#if DEBUG
    public const string Configuration = "Debug";
#else
    public const string Configuration = "Stable";
#endif

#if WindowsCE
    public const string Product = "Gisoft.GeoAPI.Net35CF";
    public const string Guid = "8ce966f8-d4fd-4437-a79c-314d9632384a";
#elif NET45
    public const string Product = "Gisoft.GeoAPI";
    public const string Guid = FullFrameworkGuid;
#elif NET403
    public const string Product = "Gisoft.GeoAPI.Net403";
    public const string Guid = FullFrameworkGuid;
#elif NET40
    public const string Product = "Gisoft.GeoAPI.Net40";
    public const string Guid = FullFrameworkGuid;
#elif NET35
    public const string Product = "Gisoft.GeoAPI.Net35";
    public const string Guid = FullFrameworkGuid;
#elif NET20
    public const string Product = "Gisoft.GeoAPI.Net20";
    public const string Guid = FullFrameworkGuid;
#elif NET46
    public const string Product = "Gisoft.GeoAPI.Net46";
    public const string Guid = FullFrameworkGuid;
#elif NET461
    public const string Product = "Gisoft.GeoAPI.Net461";
    public const string Guid = FullFrameworkGuid;
#elif NET47
    public const string Product = "Gisoft.GeoAPI.Net47";
    public const string Guid = FullFrameworkGuid;
#elif NETCOREAPP2_0
    public const string Product = "Gisoft.GeoAPI.NetCore20";
#elif NETCOREAPP1_0
    public const string Product = "Gisoft.GeoAPI.NetCore10";
#elif NETSTANDARD1_0
    public const string Product = "Gisoft.GeoAPI.NetStandard10";
#elif NETSTANDARD2_0
    public const string Product = "Gisoft.GeoAPI.NetStandard20";
#elif PCL
    public const string Product = "Gisoft.GeoAPI.PCL";
#endif
}
