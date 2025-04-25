using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace MondialMunch;
public class MondialMunchEvent {
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string ShortTitle { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime DueDate { get; private set; }
    public List<Country> EventCountries { get; private set; }

    public MondialMunchEvent(string ShortEventTitle, string EventTitle, DateTime StartDate, DateTime DueDate, List<Country> EventCountries, string EventDescription) {
        this.ShortTitle = ShortEventTitle;
        this.Title = EventTitle;
        this.Description = EventDescription;
        this.StartDate = StartDate;
        this.DueDate = DueDate;
        this.EventCountries = EventCountries;
    }

    private MondialMunchEvent() { }
}
