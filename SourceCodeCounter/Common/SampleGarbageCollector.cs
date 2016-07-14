using System;
using System.Collections;
using SourceCodeCounter.Core;

namespace SourceCodeCounter.Common
{
    public class SampleGarbageCollector
    {
        private const long MaxGarbage = 1000;
        private readonly OutputLogger _logger;

        public SampleGarbageCollector(OutputLogger outputLogger)
        {
            _logger = outputLogger;
        }
        public bool Execute(object instance = null)
        {
            if (_logger == null) return false;
            if (instance == null) instance = this;                      
            _logger.WriteLine();
            _logger.WriteLine("The highest generation is {0}", GC.MaxGeneration);

            MakeSomeGarbage();

            _logger.WriteLine("Perform a collection of generation 0 only.");
            GC.Collect(0);

            // Determine which generation myGCCol object is stored in.
            _logger.WriteLine("Generation: {0}, Total Memory: {1}", GC.GetGeneration(instance), GC.GetTotalMemory(false));

            _logger.WriteLine("Perform a collection of generation 0 & 1 only.");
            GC.Collect(1);

            // Determine which generation myGCCol object is stored in.
            _logger.WriteLine("Generation: {0}, Total Memory: {1}", GC.GetGeneration(instance), GC.GetTotalMemory(false));

            _logger.WriteLine("Perform a collection of all generations up to and including 2.");
            GC.Collect(2);

            // Determine which generation myGCCol object is stored in.
            _logger.WriteLine("Generation: {0}, Total Memory: {1}", GC.GetGeneration(instance), GC.GetTotalMemory(false));
            _logger.WriteLine("\n---------------------------------------------------------------------------\n");            
            return true;
        }

        void MakeSomeGarbage()
        {
            _logger.WriteLine("Making some garbage, that are not reachable.");

            var arrayList = new ArrayList();            
            _logger.WriteLine("ArrayList has {0} items.\nBefore:", arrayList.Count);

            _logger.WriteLine("Generation: {0}, Total Memory: {1}", GC.GetGeneration(arrayList), GC.GetTotalMemory(false));

            _logger.WriteLine("Creating objects and release them to fill up memory with unused objects.");
            for (int i = 0; i < MaxGarbage; i++)
            {
                arrayList.Add(new Object());
            }
            _logger.WriteLine("arrayList now has {0} unreferenced items.\nAfter:", arrayList.Count);
            _logger.WriteLine("Generation: {0}, Total Memory: {1}", GC.GetGeneration(arrayList), GC.GetTotalMemory(false));
            _logger.WriteLine("---------------------------------------------------------------------------");
        }
    }
}

