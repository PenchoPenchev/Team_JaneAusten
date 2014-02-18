using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaneAusten
{
    public interface ICollectable
    {
        bool isCollected { get; set; }

        void Collect();
    }
}
