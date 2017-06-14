using System;
using System.Data;
using System.Globalization;
using System.Runtime.Serialization;

namespace Library
{

    public enum Purpose
    {
        Children,
        Teenagers,
        Adults,
        Elderly,
        All
    };

    public enum Kind
    {
        Moral,
        Criminal,
        Thriller,
        Romantic,
        Fantasy,
        ScienceFiction
    };
    [DataContract]
    public class BookDescription : StateDescription
    {
        public BookDescription(Item item, string description, DateTime purchaseDate, Purpose purpose, Kind kind) : base(item)
        {
            Description = description;
            PurchaseDate = purchaseDate;
            Purpose = purpose;
            Kind = kind;
        }

        public BookDescription() : base()
        {
        }

        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime PurchaseDate { get; set; }
        [DataMember]
        public Purpose Purpose { get; set; }
        [DataMember]
        public Kind Kind { get; set; }

        public override string Serialize(ObjectIDGenerator idGenerator)
        {
            string data = "";

            data += this.GetType().FullName + ",";
            data += idGenerator.GetId(this, out bool firstTime) + ",";
            data += idGenerator.GetId(Item, out firstTime).ToString() + ",";
            data += this.Description + ",";
            data += this.PurchaseDate.ToShortDateString() + ",";
            data += this.Purpose + ",";
            data += this.Kind;

            return data;
        }

        public override void Deserialize(string[] data, SerializeHelper helper)
        {
            this.Item = helper.ItemsDictionary[data[2]];
            this.Description = data[3];
            this.PurchaseDate = DateTime.ParseExact(data[4], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            Enum.TryParse(data[5], out Purpose purpose);
            this.Purpose = purpose;
            Enum.TryParse(data[6], out Kind kind);
            this.Kind = kind;
        }
    }
}
