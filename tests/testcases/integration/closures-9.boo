import NUnit.Framework

value = 3
c = do:
	Assert.AreEqual(3, value)
	value = 4
	Assert.AreEqual(4, value)
	
c()
Assert.AreEqual(3, value, "closure cant change local variables")
