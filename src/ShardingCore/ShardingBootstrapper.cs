using ShardingCore.Extensions;
using System;
using System.Collections.Generic;
using ShardingCore.Sharding.MergeEngines.ParallelControl;

namespace ShardingCore
{
    /*
    * @Author: xjm
    * @Description:
    * @Date: Monday, 21 December 2020 09:10:07
    * @Email: 326308290@qq.com
    */
    public class ShardingBootstrapper : IShardingBootstrapper
    {
        private readonly IEnumerable<IShardingConfigOption> _shardingConfigOptions;
        private readonly DoOnlyOnce _doOnlyOnce = new DoOnlyOnce();

        public ShardingBootstrapper(IServiceProvider serviceProvider)
        {
            ShardingContainer.SetServices(serviceProvider);
            _shardingConfigOptions = ShardingContainer.GetServices<IShardingConfigOption>();
        }

        public void Start()
        {
            if (!_doOnlyOnce.IsUnDo())
                return;
            foreach (var shardingConfigOption in _shardingConfigOptions)
            {
                var instance = (IShardingDbContextBootstrapper)Activator.CreateInstance(typeof(ShardingDbContextBootstrapper<>).GetGenericType0(shardingConfigOption.ShardingDbContextType), shardingConfigOption);
                instance.Init();
            }
        }

    }
}