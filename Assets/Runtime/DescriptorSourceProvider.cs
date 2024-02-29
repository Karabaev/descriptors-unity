using System;
using com.karabaev.descriptors.abstractions.Initialization;
using Cysharp.Threading.Tasks;

namespace com.karabaev.descriptors.unity
{
  public static class DescriptorSourceProvider
  {
    public static UniTask<IDescriptorRegistrySource> GetUniAsync(this IDescriptorSourceProvider provider, string key, Type type) => 
      provider.GetAsync(key, type).AsUniTask();
  }
}