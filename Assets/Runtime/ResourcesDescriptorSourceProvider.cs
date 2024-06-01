using System;
using System.Collections.Generic;
using com.karabaev.descriptors.abstractions.Initialization;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace com.karabaev.descriptors.unity
{
  public class ResourcesDescriptorSourceProvider : IDescriptorSourceProvider
  {
    public async UniTask<IDescriptorRegistrySource> GetAsync(string key, Type type)
    {
      var resource = await Resources.LoadAsync(key, type).ToUniTask();

      if(resource == null)
        throw new KeyNotFoundException($"Could not find descriptor source from resources. Key={key}, Type={type.Name}");

      return (IDescriptorRegistrySource)resource;
    }
  }
}