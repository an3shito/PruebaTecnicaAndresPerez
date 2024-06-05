---A.	Escriba la consulta en SQL que devuelva el nombre del proyecto y sus productos correspondientes del proyecto premia cuyo código es 1
SELECT P.nombre_proyecto, PR.nombre_producto
FROM PROYECTO P
JOIN PROYECTO_PRODUCTO PP ON P.cod_proyecto = PP.cod_proyecto
JOIN PRODUCTO PR ON PP.cod_producto = PR.cod_producto
WHERE P.cod_proyecto = 1;
--- B.	Escriba una consulta SQL que devuelva los distintos mensajes que hay, indicando a qué proyecto y producto pertenecen.
SELECT M.cod_mensaje, M.mensaje_texto, PR.nombre_proyecto, PD.nombre_producto
FROM MENSAJE M
JOIN PROYECTO_PRODUCTO PP ON M.cod_proyecto = PP.cod_proyecto AND M.cod_producto = PP.cod_producto
JOIN PROYECTO PR ON M.cod_proyecto = PR.cod_proyecto
JOIN PRODUCTO PD ON M.cod_producto = PD.cod_producto;
--- C.	Escriba una consulta SQL que devuelva los distintos mensajes que hay, indicando a qué proyecto y producto pertenecen. Pero si el mensaje está en todos los productos de un proyecto, en lugar de mostrar cada producto, debe mostrar el nombre del proyecto y un solo producto que diga “TODOS”.
SELECT 
    M.cod_mensaje,
    M.mensaje_texto,
    PR.nombre_proyecto,
    CASE 
        WHEN EXISTS (
            SELECT 1 
            FROM PRODUCTO P 
            WHERE NOT EXISTS (
                SELECT 1 
                FROM PROYECTO_PRODUCTO PP 
                WHERE PP.cod_proyecto = M.cod_proyecto 
                AND PP.cod_producto = P.cod_producto
            )
        )
        THEN 'TODOS'
        ELSE PD.nombre_producto
    END AS nombre_producto
FROM 
    MENSAJE M
JOIN 
    PROYECTO PR ON M.cod_proyecto = PR.cod_proyecto
JOIN 
    PRODUCTO PD ON M.cod_producto = PD.cod_producto;