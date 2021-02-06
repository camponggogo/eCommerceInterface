Alter VIEW `epndb`.`vOrderToBplus` AS
 SELECT  case when `orderchanel` ='ECOMM' 
 then    DATE_FORMAT(date_add(date_add(date('1899-12-31'), interval floor(`docdate`) day), interval floor(86400*(`docdate`-floor(`docdate`))) second), '%d/%m/%Y')
 else DATE_FORMAT(STR_TO_DATE(`docdate`, '%d/%c/%Y'), '%d/%m/%Y')  end as `docdate`,
 '' as `docref`,                       
 case when `orderchanel` ='ECOMM' 
 then    DATE_FORMAT(date_add(date_add(date('1899-12-31'), interval floor(`docdate`) day), interval floor(86400*(`docdate`-floor(`docdate`))) second), '%d/%m/%Y')
 else DATE_FORMAT(STR_TO_DATE(`docdate`, '%d/%c/%Y'), '%d/%m/%Y')  end as `vatdate`,
 `vatref`,
 `ar-apcode`,
 `goodscode`,
 `qty`,
 `qtyfree`,
 `uprice`,
 `disc`,
 `wlcode1`,
 '' as `wlcode2`,
 `totdisc`,`remark`,'' as `Dept`,'' as `branch`,'' as `Project`
 ,`orderchanel`
  FROM `epndb`.`orders`;