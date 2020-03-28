using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.WindowsAPICodePack.PropertySystem
{
    internal static class CollectionBridgeCollectionHelper

    {

        public static object GetNativeItems(ICollectionBridgeCollectionInternal collection, object collectionBridge) => object.ReferenceEquals(collection.CollectionBridge, collectionBridge) ? collection.Items : throw new ArgumentException("The given collection bridge is not associated to this collection.");

    }

    public interface ICollectionBridgeCollection { }

    internal interface ICollectionBridgeCollectionInternal

    {

        WinCopies.Util.DotNetFix.IDisposable CollectionBridge { get; }

        object Items { get; }

        object GetNativeItems(in object collectionBridge);

    }

    public interface ICollectionBridgeProvider

    {

        object GetCollectionBridge(in object parentCollectionBridge);

    }

    public sealed class CollectionBridge<T> : WinCopies.Util.DotNetFix.IDisposable where T : class, ICollectionBridgeProvider
    {
        public bool IsDisposed { get; private set; } = false;

        private T _object;

        public T Object => IsDisposed ? throw new InvalidOperationException("The current object is disposed.") : _object;

        public CollectionBridge(in T obj) => _object = obj;

        private bool Check(in T obj, in ICollectionBridgeCollectionInternal collection)
        {
            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

            if (obj is null)

                throw new ArgumentNullException(nameof(obj));

            if (collection is null)

                throw new ArgumentNullException(nameof(collection));

            return object.ReferenceEquals(obj, Object) && object.ReferenceEquals(this, obj.GetCollectionBridge(this));
        }

        private object GetNativeItems(in T obj, in ICollectionBridgeCollectionInternal collection) => Check(obj, collection) ? collection.GetNativeItems(this) : throw new ArgumentException("The given object is not associated to this bridge.");

        public object GetNativeItems<TItems>(in T obj, in Collection<TItems> collection) => GetNativeItems(obj, (ICollectionBridgeCollectionInternal)collection);

        public object GetNativeItems(in T obj, in ValueCollection valueCollection) => GetNativeItems(obj, (ICollectionBridgeCollectionInternal)valueCollection);

        public void Dispose()

        {

            _object = null;

            IsDisposed = true;

        }

        ~CollectionBridge() => Dispose();
    }
}
