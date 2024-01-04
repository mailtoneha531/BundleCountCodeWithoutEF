﻿using CountBundle.Model;

class Program
{
    static void Main()
    {
                // Sample data
                var bike = new BundleEntity
                {
                    Name = "Bike",
                    IsPairExist = false,
                    InventoryCount = int.MaxValue,
                    Parts = new List<BundlePartEntity>
                    {
                        new BundlePartEntity { Name = "Seat", InventoryCount = 8, IsPairExist = false },
                        new BundlePartEntity
                        {
                            Name = "Pedal",
                            InventoryCount = 10,
                            IsPairExist = true
                        },
                        new BundlePartEntity
                        {
                            Name = "Wheel",
                            SubParts = new List<BundlePartSubEntity>
                            {
                                new BundlePartSubEntity { Name = "Frame", InventoryCount = 10 , IsPairExist = true},
                                new BundlePartSubEntity { Name = "Tube", InventoryCount = 10 , IsPairExist = true}
                            }
                        }
                    }
                };

        int bikesToBuild = CalculateBikes(bike);

        Console.WriteLine($"Maximum number of bikes that can be built: {bikesToBuild}");
    }
            


    public static int CalculateBikes<T>(T obj)
    {
        int minAvailableCount = int.MaxValue;
        BundleEntity bundle = new BundleEntity();
        BundlePartEntity bundlePart = new BundlePartEntity();
        BundlePartSubEntity bundleSubPart = new BundlePartSubEntity();
        if (obj is BundleEntity bundleObj)
        {
            bundle = bundleObj;
            if (bundle.Parts == null || bundle.Parts.Count == 0)
            {
                return bundle.InventoryCount;
            }
            foreach (var part in bundle.Parts)
            {
                int partAvailableCount = CalculateBikes(part) / (part.IsPairExist ? 2 : 1);
                minAvailableCount = Math.Min(minAvailableCount, partAvailableCount);
            }
        }
        else if (obj is BundlePartEntity bundlePartObj)
        {
            bundlePart = bundlePartObj;
            if (bundlePart.SubParts == null || bundlePart.SubParts.Count == 0)
            {
                return bundlePart.InventoryCount;
            }
            foreach (var part in bundlePart.SubParts)
            {
                int partAvailableCount = CalculateBikes(part) / (part.IsPairExist ? 2 : 1);
                minAvailableCount = Math.Min(minAvailableCount, partAvailableCount);
            }
        }
        else if (obj is BundlePartSubEntity bundleSubPartObj)
        {
            bundleSubPart = bundleSubPartObj;

            return bundleSubPart.InventoryCount;
        }
        return minAvailableCount;
    }
}
