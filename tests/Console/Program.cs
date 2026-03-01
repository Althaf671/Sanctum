using EntitiesProgram;
using src.Domain.Entities;
using ValueObjectsPrograms;

//===== Executable Entity Area =====//
static void RunEntity()
{
    EntitiesTest.MataKuliahEntityTest();
};
// RunEntity();


//===== Executable Value object Area =====//
static void RunValueObject()
{
    // ValueObjectsTest.IsiMateriValueObjectTest();
    ValueObjectsTest.MasaKuliahValueObjectTest();
};
RunValueObject();


//===== End to End Testing Area =====//
static void RunE2ETest()
{

};
// RunE2ETest();

