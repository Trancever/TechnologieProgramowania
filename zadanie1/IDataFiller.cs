using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Library
{
    public interface IDataFiller
    {
        List<Person> GetPeopleList();
        Dictionary<string, Item> GetItemsList();
        ObservableCollection<Event> GetEventsList();
        List<StateDescription> GetStatesList();
    }
}
