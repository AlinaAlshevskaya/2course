SELECT ������������_������
FROM ������
WHERE ���� > ALL (
    SELECT ����
    FROM ������
    WHERE ������.������������_������ LIKE '%����%'
);