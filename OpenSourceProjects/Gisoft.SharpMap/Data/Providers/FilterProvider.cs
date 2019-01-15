namespace Gisoft.SharpMap.Data.Providers
{
    /// <summary>
    /// Abstract class for providers which support the FilterMethod Delegate
    /// </summary>
    public abstract class FilterProvider
    {
        #region Delegates

        /// <summary>
        /// Filter Delegate Method
        /// </summary>
        /// <remarks>
        /// The FilterMethod delegate is used for applying a method that filters data from the dataset.
        /// The method should return 'true' if the feature should be included and false if not.
        /// <para>See the <see cref="FilterDelegate"/> property for more info</para>
        /// </remarks>
        /// <seealso cref="FilterDelegate"/>
        /// <param name="dr"><see cref="Gisoft.SharpMap.Data.FeatureDataRow"/> to test on</param>
        /// <returns>true if this feature should be included, false if it should be filtered</returns>
        public delegate bool FilterMethod(FeatureDataRow dr);

        #endregion

        /// <summary>
        /// Filter Delegate Method for limiting the datasource
        /// </summary>
        /// <remarks>
        /// <example>
        /// Using an anonymous method for filtering all features where the NAME column starts with S:
        /// <code lang="C#">
        /// myShapeDataSource.FilterDelegate = new Gisoft.SharpMap.Data.Providers.ShapeFile.FilterMethod(delegate(Gisoft.SharpMap.Data.FeatureDataRow row) { return (!row["NAME"].ToString().StartsWith("S")); });
        /// </code>
        /// </example>
        /// <example>
        /// Declaring a delegate method for filtering (multi)polygon-features whose area is larger than 5.
        /// <code>
        /// myShapeDataSource.FilterDelegate = CountryFilter;
        /// [...]
        /// public static bool CountryFilter(Gisoft.SharpMap.Data.FeatureDataRow row)
        /// {
        ///		if(row.Geometry.GetType()==typeof(Gisoft.GeoAPI.Geometries.IPolygon))
        ///			return ((row.Geometry as Gisoft.GeoAPI.Geometries.IPolygon).Area>5);
        ///		if (row.Geometry.GetType() == typeof(Gisoft.GeoAPI.Geometries.IMultiPolygon))
        ///			return ((row.Geometry as Gisoft.GeoAPI.Geometries.IMultiPolygon).Area > 5);
        ///		else return true;
        /// }
        /// </code>
        /// </example>
        /// </remarks>
        /// <seealso cref="FilterMethod"/>
        public FilterMethod FilterDelegate {get;set;}
        
    }
}
