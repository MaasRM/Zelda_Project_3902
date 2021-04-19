using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkTriForceShards
    {
        List<IItem> shards;

        public LinkTriForceShards()
        {
            shards = new List<IItem>();
        }

        public void addShard(IItem shard)
        {
            bool add = true;
            foreach (IItem item in shards) add = add && ((TriforceShardItem)item).getTriForceIndex() != ((TriforceShardItem)shard).getTriForceIndex();
            if(add )shards.Add(shard);
        }

        public List<IItem> getShards()
        {
            return shards;
        }

    }
}
