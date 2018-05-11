using Microsoft.VisualStudio.TestTools.UnitTesting;
using cw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw.Tests
{
    [TestClass()]
    public class ExercisesTests
    {
        [TestMethod()]
        public void AreAnagramsTest()
        {
            Assert.IsFalse(Exercises.AreAnagrams("jahstdbfc", "bbc"));
            Assert.IsTrue(Exercises.AreAnagrams("customers", "store scum"));
            Assert.IsTrue(Exercises.AreAnagrams("forty five", "over fifty"));
            Assert.IsFalse(Exercises.AreAnagrams(
                "An anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.",
                "An anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using alx the original letters exactly once."));

            Assert.IsFalse(Exercises.AreAnagrams(
                "Ananagram isa word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.",
                "An anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using al the original letters exactly once."));
        }

        [TestMethod()]
        public void ReplaceAllSpaceWithTest()
        {
            Assert.AreEqual(Exercises.ReplaceAllSpaceWith(" Hello    World!!! ", 'X'), "XHelloXXXXWorld!!!X");
        }
    }
}