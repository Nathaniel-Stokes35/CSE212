public class FeatureCollection // Simple classes to deserialize the GeoJSON data
{
    public List<Feature> Features { get; set; }
}

public class Feature // Pulling Properties from each Feature
{
    public Properties Properties { get; set; }
}

public class Properties // Pulling Place and Mag from Properties in JSON
{
    public string Place { get; set; }
    public double? Mag { get; set; } // Can be missing, so nullable
}