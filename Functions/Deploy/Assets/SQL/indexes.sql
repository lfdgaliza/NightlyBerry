-- This is important due to the nature of pagination by date on the initial page
create index Index_Document_CreatedAt on Document (CreatedAt)