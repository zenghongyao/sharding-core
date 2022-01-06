﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShardingCore.Core.VirtualDatabase.VirtualDataSources;
using ShardingCore.Sharding.Abstractions;

namespace ShardingCore.Core.ShardingConfigurations.Abstractions
{
    public interface IShardingConfigurationOptions<TShardingDbContext> where TShardingDbContext:DbContext,IShardingDbContext
    {
        public void AddShardingGlobalConfigOptions(ShardingConfigOptions<TShardingDbContext> shardingConfigOptions);

        public ShardingConfigOptions<TShardingDbContext>[] GetAllShardingGlobalConfigOptions();
    }
}
