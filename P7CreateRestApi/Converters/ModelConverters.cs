using P7CreateRestApi.DataTransferObject;
using P7CreateRestApi.Models.Entities;

namespace P7CreateRestApi.Converters;

public static class ModelConverters
{
    #region User

    public static User Convert(this UserEntity entity)
    {
        return new User()
        {
            Id = entity.Id,
            UserName = entity.UserName
        };
    }
    
    public static UserEntity Convert(this User user)
    {
        return new UserEntity()
        {
            Id = user.Id,
            UserName = user.UserName
        };
    }

    #endregion
    
    #region Rating
    
    public static Rating Convert(this RatingEntity entity)
    {
        return new Rating()
        {
            Id = entity.Id,
            MoodysRating = entity.MoodysRating,
            SandPRating = entity.SandPRating,
            FitchRating = entity.FitchRating,
            OrderNumber = entity.OrderNumber
        };
    }
    
    public static RatingEntity Convert(this Rating rating)
    {
        return new RatingEntity()
        {
            Id = rating.Id,
            MoodysRating = rating.MoodysRating,
            SandPRating = rating.SandPRating,
            FitchRating = rating.FitchRating,
            OrderNumber = rating.OrderNumber
        };
    }
    
    #endregion

    #region Rules

    public static RuleName Convert(this RuleEntity entity)
    {
        return new RuleName()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Json = entity.Json,
            Template = entity.Template,
            SqlStr = entity.SqlStr,
            SqlPart = entity.SqlPart
        };
    }
    
    public static RuleEntity Convert(this RuleName ruleName)
    {
        return new RuleEntity()
        {
            Id = ruleName.Id,
            Name = ruleName.Name,
            Description = ruleName.Description,
            Json = ruleName.Json,
            Template = ruleName.Template,
            SqlStr = ruleName.SqlStr,
            SqlPart = ruleName.SqlPart
        };
    }

    #endregion
    
    #region Trade
    
    public static Trade Convert(this TradeEntity entity)
    {
        return new Trade()
        {
            Id = entity.Id,
            Account = entity.Account,
            AccountType = entity.AccountType,
            BuyQuantity = entity.BuyQuantity,
            SellQuantity = entity.SellQuantity,
            BuyPrice = entity.BuyPrice,
            SellPrice = entity.SellPrice,
            TradeDate = entity.TradeDate,
            TradeSecurity = entity.TradeSecurity,
            TradeStatus = entity.TradeStatus,
            Trader = entity.Trader,
            Benchmark = entity.Benchmark,
            Book = entity.Book,
            CreationName = entity.CreationName,
            CreationDate = entity.CreationDate,
            RevisionName = entity.RevisionName,
            RevisionDate = entity.RevisionDate,
            DealName = entity.DealName,
            DealType = entity.DealType,
            SourceListId = entity.SourceListId,
            Side = entity.Side
        };
    }
    
    public static TradeEntity Convert(this Trade trade)
    {
        return new TradeEntity()
        {
            Id = trade.Id,
            Account = trade.Account,
            AccountType = trade.AccountType,
            BuyQuantity = trade.BuyQuantity,
            SellQuantity = trade.SellQuantity,
            BuyPrice = trade.BuyPrice,
            SellPrice = trade.SellPrice,
            TradeDate = trade.TradeDate,
            TradeSecurity = trade.TradeSecurity,
            TradeStatus = trade.TradeStatus,
            Trader = trade.Trader,
            Benchmark = trade.Benchmark,
            Book = trade.Book,
            CreationName = trade.CreationName,
            CreationDate = trade.CreationDate,
            RevisionName = trade.RevisionName,
            RevisionDate = trade.RevisionDate,
            DealName = trade.DealName,
            DealType = trade.DealType,
            SourceListId = trade.SourceListId,
            Side = trade.Side
        };
    }
    
    #endregion

    #region CurvePoint

    public static CurvePoint Convert(this CurvePointEntity curvePoint)
    {
        return new CurvePoint()
        {
            Id = curvePoint.Id,
            CurveId = curvePoint.CurveId,
            AsOfDate = curvePoint.AsOfDate,
            Term = curvePoint.Term,
            CurvePointValue = curvePoint.CurvePointValue,
            CreationDate = curvePoint.CreationDate
        };
    }
    
    public static CurvePointEntity Convert(this CurvePoint curvePoint)
    {
        return new CurvePointEntity()
        {
            Id = curvePoint.Id,
            CurveId = curvePoint.CurveId,
            AsOfDate = curvePoint.AsOfDate,
            Term = curvePoint.Term,
            CurvePointValue = curvePoint.CurvePointValue,
            CreationDate = curvePoint.CreationDate
        };
    }

    #endregion
    
    #region Bid
    
    public static BidList Convert(this BidEntity bid)
    {
        return new BidList()
        {
            Id = bid.Id,
            Account = bid.Account,
            BidType = bid.BidType,
            BidQuantity = bid.BidQuantity
        };
    }
    
    public static BidEntity Convert(this BidList bidList)
    {
        return new BidEntity()
        {
            Id = bidList.Id,
            Account = bidList.Account,
            BidType = bidList.BidType,
            BidQuantity = bidList.BidQuantity
        };
    }
    
    #endregion
}