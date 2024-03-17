using System;
using System.Collections.Generic;
using System.Linq;
using com.karabaev.descriptors.abstractions;
using com.karabaev.descriptors.abstractions.Initialization;
using UnityEngine;

namespace com.karabaev.descriptors.unity
{
  public abstract class ScriptableObjectDescriptorRegistrySource<TId, TDescriptor, TProvider> : ScriptableObject, IDescriptorRegistrySource
    where TId : IEquatable<TId>
    where TDescriptor : IDescriptor
    where TProvider : IDescriptorSourceProvider

  {
    [SerializeField]
    private Item[] _items = Array.Empty<Item>();

    public abstract string Key { get; }

    public Type DescriptorType => typeof(TDescriptor);

    public Type ProviderType => typeof(TProvider);

    public IReadOnlyDictionary<object, IDescriptor> Descriptors => _items.ToDictionary(i => (object)i.Id, i => (IDescriptor)i.Descriptor);

    [Serializable]
    public record Item
    {
      [field: SerializeField]
      public TId Id { get; private set; } = default!;

      [field: SerializeField]
      public TDescriptor Descriptor { get; private set; } = default!;
    }
  }
}