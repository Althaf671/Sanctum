using EntitiesProgram;
using src.Domain.Entities;
using ValueObjectsPrograms;

//===== Executable Entity Area =====//
static void RunEntity()
{
    MataKuliahAggregateEntities.MataKuliahEntityTest();
};
// RunEntity();


//===== Executable Value object Area =====//
static void RunValueObject()
{
    ValueObjectsTest.IsiMateriValueObjectTest();
    ValueObjectsTest.MasaKuliahValueObjectTest();
    ValueObjectsTest.UrlValueObjectTest();
    ValueObjectsTest.WaktuKuliahValueObjectTest();
};
RunValueObject();


//===== End to End Testing Area =====//
static void RunE2ETest()
{

};
// RunE2ETest();

