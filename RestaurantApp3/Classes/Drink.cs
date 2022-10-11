using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp3.Classes
{
	abstract class Drinks : MenuItem //, IDisposable
	{
		static int counter = 0;
		//private bool disposedValue = false;

		public Drinks()
		{
			counter++;
		}
		public override string ToString()
		{
			return this.GetType().Name + " " + counter;
		}

		//protected virtual void Dispose(bool disposing)
		//{
		//	if (!disposedValue)
		//	{
		//		if (disposing)
		//		{
		//			// TODO: dispose managed state (managed objects)
		//		}

		//		// TODO: free unmanaged resources (unmanaged objects) and override finalizer
		//		// TODO: set large fields to null
		//		disposedValue = true;
		//	}
		//}

		//// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
		//~Drinks()
		//{
		//	// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		//	Dispose(disposing: false);
		//}

		//public void Dispose()
		//{
		//	// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		//	Dispose(disposing: true);
		//	GC.SuppressFinalize(this);
		//}
	}

	sealed class Tea : Drinks
	{
		public override void Obtain()
		{
		}


		public override void Serve()
		{
		}
	}
	sealed class CocaCola : Drinks
	{

		public override void Obtain()
		{
		}

		public override void Serve()
		{
		}
	}
	sealed class Pepsi : Drinks
	{
		public override void Obtain()
		{
		}

		public override void Serve()
		{
		}
	}
}
