ALTER Table GeneralInfo
ADD UsesModel  bit NOT NULL CONSTRAINT [DF_GeneralInfo_usesModel]  DEFAULT ((0)) ,
    PriceRate Decimal (16,4) NULL