SELECT 	a.order_id, a.order_total, a.order_subtotal, a.order_tax, from_unixtime(a.cdate), from_unixtime(a.mdate),a.customer_note,
		b.company, b.first_name, b.last_name, b.phone_1, b.phone_2, b.address_1, b.address_2,b.city,b.zip,b.user_email
FROM resto_boulot_fr_new.jos_vm_orders as a
inner join jos_vm_order_user_info as b on a.order_id = b.order_id
where DATE( from_unixtime(a.cdate) ) = DATE('2013-10-21')