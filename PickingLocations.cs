using System.Collections.Generic;
using System;
using System.Text;
using System.Linq;


class PickingLocations
{
    private List<Location> locations;
    private int defaultUnitOfMeasure;

    public PickingLocations(List<Location> locations, int defaultUnitOfMeasure = 1)
    {
        this.locations = locations;
        this.defaultUnitOfMeasure = defaultUnitOfMeasure;
    }

    public List<InventoryToPick> Calculate(int quantityToPick)
    {
        // Implement the logic here
        List<Location> oLocationWithItem = new List<Location>();
        List<InventoryToPick> oResult = new List<InventoryToPick>();
        Int32 QuantityPending = 0;
        Int32 TotalInStuck;
        try
        {
            oLocationWithItem = locations.
                OrderBy(x => x.QuantityAvailable).ToList();

            TotalInStuck = oLocationWithItem.Sum(x=> x.QuantityAvailable);        
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        //lanzar error si lo solicitado excede el total disponible
        if (quantityToPick > TotalInStuck)
            throw new Exception("We dont have this quantity in stuck");

        QuantityPending = quantityToPick;

        Location oLocation;
        List<Location> oListLocation;

        oLocation = oLocationWithItem.Find(x => x.QuantityAvailable >= quantityToPick);


        if (oLocation != null)
        {
            oResult.Add(new InventoryToPick()
            { LocationId = oLocation.Id, Quantity = quantityToPick });
            return oResult;
        }
        else
        {
            oListLocation = oLocationWithItem.FindAll(x => x.QuantityAvailable % defaultUnitOfMeasure == 0
                && x.QuantityAvailable <= quantityToPick);

            foreach(Location o in oListLocation)
                oResult.Add(new InventoryToPick()
                { LocationId = o.Id, Quantity = quantityToPick });
        }

        return oResult;
    }
}


class Location
{
    public int Id { get; set; }
    public int QuantityAvailable { get; set; }
}


class InventoryToPick
{
    public int LocationId { get; set; }
    public int Quantity { get; set; }
}
