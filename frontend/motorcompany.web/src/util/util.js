export const formatCurrency = number =>
  new Intl.NumberFormat("en-CA", { style: "currency", currency: "CAD" }).format(
    number
  );

export const formatDate = date => new Intl.DateTimeFormat("en-CA").format(date);
