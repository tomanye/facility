ALTER Table GeneralInfo
ADD usesModel  bit NOT NULL CONSTRAINT [DF_GeneralInfo_usesModel]  DEFAULT ((0)) 