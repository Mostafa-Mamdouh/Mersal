#region Using ...
using Framework.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Common
{
	public class GenericComparer<T> : IComparer<T>
			where T : ICode
	{
		public int Compare(T first, T second)
		{
			try
			{
				return first.Code.CompareTo(second.Code);
			}
			catch
			{
				return 0;
			}
		}
	}
}
