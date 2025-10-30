
namespace LibreriaCalcolatrice.Tests.Tests;

public class UnitTest
{ 

    //ARRANGE

    [Fact]
    public void SommaDueNumeriRestituisceSommaAritmetica()
    {
        IClock day = new MockWednesdayClock();
        Calcolatrice calcolatrice = new Calcolatrice(day);

        int a = 1;
        int b = 2;
        int atteso = 3;
        //ACT
        var result = calcolatrice.Somma(a, b);
        //ASSERT
        Assert.Equal(result, atteso);
    }

    [Fact]
    public void SommaZeroRestituisceNumeriDiPartenza()
    {
        //ARRANGE
        IClock day = new MockWednesdayClock();
        Calcolatrice calcolatrice = new Calcolatrice(day);

        int a = 1;
        int b = 0;
        int atteso = 1;
        //ACT
        var result = calcolatrice.Somma(a, b);
        //ASSERT
        Assert.Equal(result, atteso);
    }

    [Fact]
    public void SommoNegativoRestituisceZero()
    {
        //ARRANGE
        IClock day = new MockWednesdayClock();
        Calcolatrice calcolatrice = new Calcolatrice(day);

        int a = 1;
        int b = -1;
        int atteso = 0;
        //ACT
        var result = calcolatrice.Somma(a, b);
        //ASSERT
        Assert.Equal(result, atteso);
    }
    [Fact]
    public void EseguoTestMartediPerSommaPazza()
    {
        IClock day = new MockTuesdayClock();
        Calcolatrice calcolatrice = new Calcolatrice(day);

        int a = 2;
        int b = 3;
        int atteso = 13;
        //ACT
        var result = calcolatrice.Somma(a, b);
        //ASSERT
        Assert.Equal(result, atteso);
    }
    [Fact]
    public void EseguoTestMercolediPerSommaNormale()
    {
        IClock day = new MockWednesdayClock();
        Calcolatrice calcolatrice = new Calcolatrice(day);
        int a = 1;
        int b = -1;
        int atteso = 0;
        //ACT
        var result = calcolatrice.Somma(a, b);
        //ASSERT
        Assert.Equal(result, atteso);
    }
}
