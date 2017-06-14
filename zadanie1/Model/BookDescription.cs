using System;
using System.Globalization;
using System.Runtime.Serialization;
using Library.Serializers;

namespace Library.Model
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
            data += this.PurchaseDate.ToString("MM.dd.yyyy") + ",";
            data += this.Purpose + ",";
            data += this.Kind;

            return data;
        }

        public override bool Deserialize(string[] data, SerializeHelper helper)
        {
            if (this.GetType().GetProperties().Length != data.Length - 2) return false;
            try
            {
                this.Item = helper.ItemsDictionary[data[2]];
                this.Description = data[3];
                this.PurchaseDate = DateTime.ParseExact(data[4], "M.d.yyyy", CultureInfo.InvariantCulture);
                Enum.TryParse(data[5], out Purpose purpose);
                this.Purpose = purpose;
                Enum.TryParse(data[6], out Kind kind);
                this.Kind = kind;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }
    }
}
