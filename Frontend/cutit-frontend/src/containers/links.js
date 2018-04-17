import React from 'react';

import Pagination from '../components/Pagination';
import LinksTable from '../components/LinksTable';

import { CFG_HTTP } from '../cfg/cfg_http';
import { UtilsApi } from '../utils/utils_api';

class LinksContainer extends React.Component {
    constructor(){
        super();

        this.state = {
            links: [],
            currentPage: 1,
            maxPage: 1
        };
    }

    fetchLinks = (currentPage = 1) => {
        let sendData = {Page: currentPage, ItemPerPage: 1};
        
        UtilsApi
          .get(CFG_HTTP.URL_LINKS, sendData)
          .then((linksResult) => {
            this.setState({
              links: linksResult.links,
              pagesLimit: linksResult.pageInfo.maxPage,
              currentPage: linksResult.pageInfo.currentPage
            });
          });
      };
    
    componentDidMount() {
        this.fetchLinks();
    }

    handlePageChange = (pageNumber) => {
        this.fetchLinks(pageNumber);
    }

    render() {
        return (
            <React.Fragment>
                <Pagination currentPage={this.state.currentPage}
                        pagesLimit={this.state.pagesLimit}
                        onPageChange={this.handlePageChange}/>
                <LinksTable links={this.state.links}/>        
            </React.Fragment>
        );
    }
}

export default LinksContainer;