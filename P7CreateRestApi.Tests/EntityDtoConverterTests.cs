using P7CreateRestApi.Converters;
using P7CreateRestApi.DataTransferObject;
using P7CreateRestApi.Models.Entities;

namespace P7CreateRestApi.Tests;

public class EntityDtoConverterTests
{
    /// <summary>
    /// L'objectif de ce test est de vérifier que le nom du compte et son type ne sont pas null et ne contiennent pas d'espaces blancs
    /// </summary>
    [Theory]
    [InlineData("A-546", "Achat")]
    public void CheckAccountAndAccountTypeIsNotNullOrWhitespaceFree(string account, string bidType)
    {
        // Arrange 
        var bid = new BidList()
        {
            Account = account,
            BidType = bidType,
            BidQuantity = 100.50,
        };

        // Act
        var isAccountNullOrWhiteSpace = string.IsNullOrWhiteSpace(bid.Account) 
                                        || string.IsNullOrEmpty(bid.Account);
        
        var isBidTypeNullOrWhiteSpace = string.IsNullOrWhiteSpace(bid.BidType) 
                                        || string.IsNullOrEmpty(bid.BidType);

        // Assert

        //S'assure que le nom du compte et son type n'est pas null ou qu'il ne contient pas d'espaces blancs
        Assert.False(isAccountNullOrWhiteSpace, $"Le nom du compte \"{bid.Account}\" est null ou contient des espaces blancs.");
        Assert.False(isBidTypeNullOrWhiteSpace, $"Le type de compte \"{bid.BidType}\" est null ou contient des espaces blancs.");
    }

    /// <summary>
    /// L'objectif de ce test est de vérifier que la conversion d'un objet BidList en BidEntity fonctionne correctement
    /// </summary>
    [Theory]
    [InlineData("A-546", "Achat")]
    public void CheckDtoConvertToEntity(string account, string bidType)
    {
        // Arrange 
        var bid = new BidList()
        {
            Account = account,
            BidType = bidType,
            BidQuantity = 100.50,
        };

        // Act
        var bidEntity = bid.Convert();
        
        // Assert

        //S'assure que le type de l'entité convertie est BidEntity
        Assert.IsType<BidEntity>(bidEntity);
    }
    
    /// <summary>
    /// L'objectif de ce test est de vérifier que le curveId est dans la plage de valeurs autorisées (0-255)
    /// </summary>
    [Theory]
    [InlineData(89)]
    public void CheckCurveIdRange(int curveId)
    {
        // Arrange 
        
        // Act
        var isValueInRange = curveId is >= byte.MinValue and <= byte.MaxValue;
        
        // Assert

        //S'assure que le curve id est dans la plage de valeurs autorisées (byte)
        Assert.True(isValueInRange, $"Le curve id {curveId} n'est pas dans la plage de valeurs autorisées (0-255).");
    }
    
    /// <summary>
    /// L'objectif de ce test est de vérifier que la conversion d'un objet CurvePoint en CurvePointEntity fonctionne correctement
    /// </summary>
    [Theory]
    [InlineData(89)]
    public void CheckCurvePointDtoConvertToEntity(byte curveId)
    {
        // Arrange 
        var curvePoint = new CurvePoint()
        {
            CurveId = curveId,
            AsOfDate = DateTime.Now,
            Term = 5,
            CreationDate = DateTime.Now,
            CurvePointValue = 100.50,
        };

        // Act
        var curvePointEntity = curvePoint.Convert();
        
        // Assert

        //S'assure que le type de l'entité convertie est CurvePointEntity
        Assert.IsType<CurvePointEntity>(curvePointEntity);
    }
}