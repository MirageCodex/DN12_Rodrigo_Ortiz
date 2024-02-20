SELECT ci.city_id, ci.country_id,ci.last_update, co.country FROM country co 
INNER JOIN city ci ON co.country_id = ci.country_id
where co.country_id = 2;

SELECT COUNT(*) total_films, rating FROM film f
GROUP BY rating HAVING COUNT(*) > 200;

SELECT c.name ,sub.rating, sub.total_films FROM film f 
INNER JOIN  film_category fc ON f.film_id= fc.film_id
INNER JOIN category c ON fc.category_id = c.category_id
INNER JOIN (SELECT COUNT(*) total_films, rating FROM film f
GROUP BY rating HAVING COUNT(*) > 200) sub ON f.rating = sub.rating
GROUP BY c.name ,sub.rating, sub.total_films
ORDER BY sub.total_films DESC;

SELECT 'Mayor cantidad' querry_type,sub2.total_films, a.actor_id, a.first_name, a.last_name FROM(
SELECT MAX(total_films) max_films FROM(
SELECT COUNT(*) total_films,actor_id FROM film_actor
GROUP BY actor_id) sub)sub_max
INNER JOIN (
SELECT COUNT(*) total_films,actor_id FROM film_actor
GROUP BY actor_id) sub2 ON sub_max.max_films = sub2.total_films
INNER JOIN actor a on a.actor_id = sub2.actor_id
UNION
SELECT 'Menor Cantidad' querry_type,sub2.total_films, a.actor_id, a.first_name, a.last_name FROM(
SELECT MIN(total_films) min_films FROM(
SELECT COUNT(*) total_films,actor_id FROM film_actor
GROUP BY actor_id) sub)sub_min
INNER JOIN (
SELECT COUNT(*) total_films,actor_id FROM film_actor
GROUP BY actor_id) sub2 ON sub_min.min_films = sub2.total_films
INNER JOIN actor a on a.actor_id = sub2.actor_id

