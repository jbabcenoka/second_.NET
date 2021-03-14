using System;
using System.Collections.Generic;
using System.Text;

namespace uzdevums1
{

    public interface IDataManager
    {
        public string Print();

        public void Save(string path);

        public void Load(string path);

        public void CreateTestData();
        public void Reset();


    }
}
