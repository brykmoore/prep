configs ={
  :git => {
    :provider => 'github',
    :user => 'remoteoctober2014',
    :remotes => potentially_change("remotes",__FILE__),
    :repo => 'prep' 
  }
}
configatron.configure_from_hash(configs)
