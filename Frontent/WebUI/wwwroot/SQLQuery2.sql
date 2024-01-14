-- Eksempel på spørring: Legge til 2 produkter for alle kategorier
INSERT INTO Products (ProductName, Description, Price, ImageUrl, Status, CategoryId)
VALUES

('Cheeseburger', 'Delicious hamburger with cheese', 8.99, 'cheeseburger.jpg', 1, 1),
  ('Chicken Nuggets', 'Crispy chicken nuggets with dipping sauce', 6.99, 'chicken-nuggets.jpg', 1, 1),
  
  -- Hamburger kategorisi için ürünler
  ('Classic Burger', 'Classic burger with fresh ingredients', 10.99, 'classic-burger.jpg', 1, 1),
  ('Vegetarian Burger', 'Tasty vegetarian burger with veggies', 9.99, 'vegetarian-burger.jpg', 1, 1),


  -- For retter kategorien produkter
  ('Biff Stroganoff', 'Saftig biff med fløtesaus og sopp', 15.99, 'biff-stroganoff.jpg', 1, 2),
  ('Laks med Sitronsaus', 'Fersk laks grillet til perfeksjon', 19.99, 'laks-sitronsaus.jpg', 1, 2),
  
  -- Dessert kategorien produkter
  ('Sjokoladefondue', 'Deilig sjokolade for dypping av frukt', 12.99, 'sjokoladefondue.jpg', 1, 3),
  ('Panna Cotta med Bær', 'Fløyelsmyk panna cotta med friske bær', 14.99, 'panna-cotta-baer.jpg', 1, 3),

  -- Drikkevarer kategorien produkter
  ('Cappuccino', 'Sterk espresso med myk melkeskum', 4.99, 'cappuccino.jpg', 1, 4),
  ('Fersk Appelsinjuice', 'Nypresset juice fra ferske appelsiner', 5.99, 'fersk-appelsinjuice.jpg', 1, 4),

  -- Vegetarretter kategorien produkter
  ('Quinoa Salat', 'Sunn quinoa salat med ferske grønnsaker', 9.99, 'quinoa-salat.jpg', 1, 5),
  ('Vegetarburger', 'Deilig vegetarburger med friske grønnsaker', 11.99, 'vegetarburger.jpg', 1, 5),

  -- Fiskeretter kategorien produkter
  ('Grillet Laks', 'Fersk grillet laksefilet', 17.99, 'grillet-laks.jpg', 1, 6),
  ('Rekesalat', 'Deilig salat med ferske reker', 14.99, 'rekesalat.jpg', 1, 6),

  -- Forretter kategorien produkter
  ('Kremet Rekesuppe', 'Appetittvekkende rekesuppe', 8.99, 'kremet-rekesuppe.jpg', 1, 7),
  ('Caprese Salat', 'Deilig salat med fersk mozzarella', 10.99, 'caprese-salat.jpg', 1, 7),

  -- Snacks kategorien produkter
  ('Sprø Potetchips', 'Sprø potetchips', 6.99, 'spro-potetchips.jpg', 1, 8),
  ('Nachos med Salsa', 'Nachos med deilig salsa', 8.99, 'nachos-salsa.jpg', 1, 8),

  -- Supper kategorien produkter
  ('Tomatsuppe', 'Varm tomat suppe laget med friske tomater', 7.99, 'tomatsuppe.jpg', 1, 9),
  ('Kjøttbolle Nudelsuppe', 'Nudelsuppe med kjøttboller', 9.99, 'kjottbolle-nudelsuppe.jpg', 1, 9);


   -- Søndagsmiddag kategorisi için ürünler

  -- Salater kategorisi için ürünler
  