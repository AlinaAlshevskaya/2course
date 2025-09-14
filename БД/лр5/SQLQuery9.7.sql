SELECT Наименование_товара
FROM Товары
WHERE Цена > ALL (
    SELECT Цена
    FROM Товары
    WHERE Товары.Наименование_товара LIKE '%ваза%'
);