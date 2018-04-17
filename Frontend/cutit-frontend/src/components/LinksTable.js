import Grid from 'material-ui/Grid';
import PropTypes from 'prop-types';
import React from 'react';
import Table, {
  TableBody,
  TableCell,
  TableHead,
  TableRow
} from 'material-ui/Table';

import LinkInterface from '../interfaces/link';

const LinksTable = (props) => {
  const links = props.links.map((link) => {
    return (
      <TableRow key={link.id}>
        <TableCell>{link.originalLink}</TableCell>
        <TableCell>{link.shortLink}</TableCell>
      </TableRow>
    );
  });

  return (
    <Grid className="linksTable" container>
      <Grid item xs={12} md={8}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Original Link</TableCell>
              <TableCell>Short Link</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {links}
          </TableBody>
        </Table>
      </Grid>
    </Grid>
  );
}

LinksTable.propTypes = {
  links: PropTypes.arrayOf(LinkInterface)
};

export default LinksTable;