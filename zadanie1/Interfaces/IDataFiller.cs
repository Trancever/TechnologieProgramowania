using System.Collections.Generic;
using System.Collections.ObjectModel;
using Library.Model;


namespace Library.Interfaces
{
    public interface IDataFiller
    {
        List<Person> GetPeopleList();
        Dictionary<string, Item> GetItemsList();
        ObservableCollection<Event> GetEventsList();
        List<StateDescription> GetStatesList();
    }
}
