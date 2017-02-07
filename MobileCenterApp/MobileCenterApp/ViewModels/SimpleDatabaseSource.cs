using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using SimpleDatabase;

namespace MobileCenterApp
{
	public class SimpleDatabaseSource<T> : IList, INotifyCollectionChanged where T : new()
	{
		public object this[int index]
		{
			get
			{
				Debug.WriteLine($"Loading {index}");
				return new GroupedList<T>(Database,GroupInfo, index)
				{
					Display = Database?.SectionHeader<T>(GroupInfo,index) ?? "",
				};
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		GroupInfo groupInfo;

		public event NotifyCollectionChangedEventHandler CollectionChanged;

		public void ResfreshData()
		{
			CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs (NotifyCollectionChangedAction.Reset));
		}

		public GroupInfo GroupInfo
		{
			get { return groupInfo ?? (groupInfo =Database.GetGroupInfo<T>()); }
			set { 
				groupInfo = value;
				ResfreshData();
			}
		}

		public int Count => Database?.NumberOfSections<T>(GroupInfo) ?? 0;

		public SimpleDatabase.SimpleDatabaseConnection Database { get; set; }

		public bool IsFixedSize => true;

		public bool IsReadOnly => true;

		public bool IsSynchronized
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public object SyncRoot
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public int Add(object value)
		{
			throw new NotImplementedException();
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public bool Contains(object value)
		{
			throw new NotImplementedException();
		}

		public void CopyTo(Array array, int index)
		{
			throw new NotImplementedException();
		}

		public IEnumerator GetEnumerator()
		{
			int position = -1;
			while (position < Count - 1)
			{
				position++;
				yield return this[position];
			}
		}

		public int IndexOf(object value)
		{
			throw new NotImplementedException();
		}

		public void Insert(int index, object value)
		{
			throw new NotImplementedException();
		}

		public void Remove(object value)
		{
			throw new NotImplementedException();
		}

		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}


	}
	public class GroupedList<T> : IList where T : new()
	{
		public GroupedList(SimpleDatabase.SimpleDatabaseConnection database, GroupInfo groupInfo, int section)
		{
			GroupInfo = groupInfo;
			Database = database;
			Section = section;
		}
		public GroupInfo GroupInfo { get; set; }
		public string Display { get; set; } = "";

		public SimpleDatabase.SimpleDatabaseConnection Database { get; set; }
		public int Section { get; set; }

		public bool IsReadOnly => true;

		public bool IsFixedSize => true;

		public int Count => Database?.RowsInSection<T>(GroupInfo,Section) ?? 0;

		public object SyncRoot
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool IsSynchronized
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public object this[int index]
		{
			get
			{
				Debug.WriteLine($"Loading {Section}:{index}");
				return Database.ObjectForRow<T>(GroupInfo, Section, index);
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public int Add(object value)
		{
			throw new NotImplementedException();
		}

		public bool Contains(object value)
		{
			throw new NotImplementedException();
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public int IndexOf(object value)
		{
			throw new NotImplementedException();
		}

		public void Insert(int index, object value)
		{
			throw new NotImplementedException();
		}

		public void Remove(object value)
		{
			throw new NotImplementedException();
		}

		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		public void CopyTo(Array array, int index)
		{
			throw new NotImplementedException();
		}

		public IEnumerator GetEnumerator()
		{
			int position = -1;
			var count = Count;
			while (position < count - 1)
			{
				position++;
				yield return this[position];
			}
		}
	}
}
