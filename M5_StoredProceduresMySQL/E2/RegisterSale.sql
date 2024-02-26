CREATE DEFINER=`root`@`localhost` PROCEDURE `RegisterSale`(
	IN productId INT,
    IN userId INT)
BEGIN
	DECLARE inventoryId INT;
    DECLARE measureTypeId INT;
    DECLARE productTypeId INT;

    SELECT idinventory, mesuretypes_idmesuretypes, producttypes_idproducttypes 
    INTO inventoryId, measureTypeId, productTypeId 
    FROM inventory 
    WHERE idinventory = productId;

    INSERT INTO sales (cuantity, salesdate, inventory_idinventory, inventory_mesuretypes_idmesuretypes, inventory_producttypes_idproducttypes)
    VALUES (1, NOW(), inventoryId, measureTypeId, productTypeId);

    UPDATE inventory
    SET stock = stock - 1
    WHERE idinventory = productId;
    
     SELECT inventoryId, measureTypeId, productTypeId;
END