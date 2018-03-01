with dups as  (
SELECT 
   COUNT(CARD_ID)  OVER (PARTITION BY cade_id, leve_id) cardCount
   cade_id,
   leve_id
FROM  carddetails 
)
    SELECT * 
    FROM   cards c 
           INNER JOIN carddetails cd 
             ON c.card_id = cd.card_id 
           INNER JOIN  dups 
             ON cd.cade_id = dups.cade_id 
                AND cd.leve_id = dups.leve_id 
    WHERE cardCount > 1