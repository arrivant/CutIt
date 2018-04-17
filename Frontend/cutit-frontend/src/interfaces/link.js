import PropTypes from "prop-types";

const LinkInterface = PropTypes.shape({
  id: PropTypes.number.required,
  originalLink: PropTypes.string.required,
  shortLink: PropTypes.string.required,
});

export default LinkInterface;
