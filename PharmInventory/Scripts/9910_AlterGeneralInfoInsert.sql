ALTER PROCEDURE [dbo].[proc_GeneralInfoInsert]
(
	@ID int = NULL output,
	@HospitalName varchar(50) = NULL,
	@Woreda int = NULL,
	@Zone int = NULL,
	@Region int = NULL,
	@Telephone varchar(50) = NULL,
	@HospitalContact varchar(50) = NULL,
	@LeadTime int = NULL,
	@Min int = NULL,
	@Max int = NULL,
	@SafteyStock int = NULL,
	@AMCRange int = NULL,
	@ReviewPeriod int = NULL,
	@EOP float = NULL,
	@Description text = NULL,
	@IsEven bit = NULL,
	@Logo varchar(50) = NULL,
	@DUMin float = NULL,
	@DUMax float = NULL,
	@DUAMCRange int = NULL,
	@LastBackUp datetime = NULL,
	@FacilityID int = NULL,
	@LastSync datetime = NULL,
	@DSUpdateFrequency varchar(50) = NULL,
	@RRFStatusUpdateFrequency varchar(50) = NULL,
	@RRFStatusFirstUpdateAfter varchar(50) = NULL,
	@ScmsWSUserName nvarchar(100) = NULL,
	@ScmsWSPassword nvarchar(100) = NULL,
	@UsesModel bit,
	@PriceRate decimal(16,4) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [GeneralInfo]
	(
		[HospitalName],
		[Woreda],
		[Zone],
		[Region],
		[Telephone],
		[HospitalContact],
		[LeadTime],
		[Min],
		[Max],
		[SafteyStock],
		[AMCRange],
		[ReviewPeriod],
		[EOP],
		[Description],
		[IsEven],
		[Logo],
		[DUMin],
		[DUMax],
		[DUAMCRange],
		[LastBackUp],
		[FacilityID],
		[LastSync],
		[DSUpdateFrequency],
		[RRFStatusUpdateFrequency],
		[RRFStatusFirstUpdateAfter],
		[ScmsWSUserName],
		[scmsWSPassword],
		[UsesModel],
		[PriceRate]

	)
	VALUES
	(
		@HospitalName,
		@Woreda,
		@Zone,
		@Region,
		@Telephone,
		@HospitalContact,
		@LeadTime,
		@Min,
		@Max,
		@SafteyStock,
		@AMCRange,
		@ReviewPeriod,
		@EOP,
		@Description,
		@IsEven,
		@Logo,
		@DUMin,
		@DUMax,
		@DUAMCRange,
		@LastBackUp,
		@FacilityID,
		@LastSync,
		@DSUpdateFrequency,
		@RRFStatusUpdateFrequency,
		@RRFStatusFirstUpdateAfter,
		@ScmsWSUserName,
		@ScmsWSPassword,
		@UsesModel,
		@PriceRate
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
