namespace CustomCollections.cs
{
    using Contracts;

    using System;

    public class MyList<Item> : ITypeable
    {
        public MyList()
        {
            this.Count = 0;
            this.capacity = 4;
            this.workArray = new Item[this.capacity];
            this.typeName = this.FindType();
            this.type = this.SetAsType();
        }

        private object average;

        private int capacity;

        private int sum;

        private string typeName;

        private Type type;

        private Item[] workArray;

        public int Count { get; private set; }

        public object Sum
        {
            get
            {
                return this.sum;
            }
            private set
            {

            }
        }

        public object Average
        {
            get
            {
                return this.average;
            }
            private set
            {

            }
        }

        public void AddItem(Item value)
        {
            this.workArray[this.Count] = value;
        }

        public String FindType()
        {
            string name = this.workArray.GetType().Name;
            return name.Substring(0, name.Length - 2);
        }

        private Type SetAsType()
        {
            if (this.typeName == "Boolean")
            {
                return typeof(Boolean);
            }
            else if (this.typeName == "Byte")
            {
                return typeof(Byte);
            }
            else if (this.typeName == "SByte")
            {
                return typeof(SByte);
            }
            else if (this.typeName == "Char")
            {
                return typeof(Char);
            }
            else if (this.typeName == "Decimal")
            {
                return typeof(Decimal);
            }
            else if (this.typeName == "Double")
            {
                return typeof(Double);
            }
            else if (this.typeName == "Single")
            {
                return typeof(Single);
            }
            else if (this.typeName == "Int32")
            {
                return typeof(Int32);
            }
            else if (this.typeName == "UInt32")
            {
                return typeof(UInt32);
            }
            else if (this.typeName == "Int64")
            {
                return typeof(Int64);
            }
            else if (this.typeName == "UInt64")
            {
                return typeof(UInt64);
            }
            else if (this.typeName == "Object")
            {
                return typeof(Object);
            }
            else if (this.typeName == "Int16")
            {
                return typeof(Int16);
            }
            else if (this.typeName == "UInt16")
            {
                return typeof(UInt16);
            }
            else if (this.typeName == "String")
            {
                return typeof(String);
            }
            else
            {
                return Type.GetType(this.typeName);
            }
        }

        protected event TypeEventHandler valueType;

        event TypeEventHandler ITypeable.ValueType
        {
            add
            {
                this.valueType += value;
            }

            remove
            {
                this.valueType -= value;
            }
        }
    }
}
