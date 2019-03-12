-- Script Date: 08.03.2019 18:16  - ErikEJ.SqlCeScripting version 3.5.2.80
-- Database information:
-- Database: F:\C#\InvestStat\stat.db
-- ServerVersion: 3.24.0
-- DatabaseSize: 24 KB
-- Created: 05.03.2019 15:02

-- User Table information:
-- Number of tables: 5
-- Companies: -1 row(s)
-- CompanyFinancialInformation: -1 row(s)
-- CompanyModificators: -1 row(s)
-- CompanySWOT: -1 row(s)
-- SharePrice: -1 row(s)

SELECT 1;
PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE [SharePrice] (
  [CompanyId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [PriceTimestamp] text NOT NULL
, [Price] numeric(53,0) NOT NULL
);
CREATE TABLE [CompanySWOT] (
  [CompanyId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Strengths] text NULL
, [Weaknesses] text NULL
, [Opportunities] text NULL
, [Threats] text NULL
);
CREATE TABLE [CompanyModificators] (
  [CompanyId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [ActualYear] text NULL
, [EarningsPerShare] numeric(53,0) NULL
, [PriceToEarnings] numeric(53,0) NULL
, [PriceToSales] numeric(53,0) NULL
, [PriceToBookValue] numeric(53,0) NULL
, [EnterpriseValue] numeric(53,0) NULL
, [MergersAndAcquisitions] numeric(53,0) NULL
, [Debt_EBITDA] numeric(53,0) NULL
, [EV_EBITDA] numeric(53,0) NULL
, [ReturnOnCommonEquity] numeric(53,0) NULL
, [EBITDA] numeric(53,0) NULL
);
CREATE TABLE [CompanyFinancialInformation] (
  [CompanyId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [ActualYear] text NULL
, [Assets] numeric(53,0) NULL
, [Liabilities] numeric(53,0) NULL
, [Earnings] numeric(53,0) NULL
, [Price] numeric(53,0) NULL
, [Sales] numeric(53,0) NULL
, [BookValue] numeric(53,0) NULL
, [EnterpriseValue] numeric(53,0) NULL
);

COMMIT;

